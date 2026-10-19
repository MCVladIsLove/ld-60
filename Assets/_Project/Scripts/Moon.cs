using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _oilConsumtion = 100;
    [SerializeField] private int _oilNeeded = 5000;
    [SerializeField] private OilProjectileAnimationSpawner _oilProjectileAnimationSpawner;
    [SerializeField] private float _maxIdleScale = 1.2f;
    [SerializeField] private float _idleDuration = 1f;
    [SerializeField] private Ease _idleEase;
    [SerializeField] private float _pulseScale = 1.1f;
    [SerializeField] private float _pulseDuration = 0.15f;
    [SerializeField] private Ease _pulseEase;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _minRotation;
    [SerializeField] private float _maxRotation;
    [SerializeField] private float _minRotationStep;
    [SerializeField] private float _maxRotationStep;
    [SerializeField] private float _rotationDuration;
    [SerializeField] private Ease _rotationEase;
    [SerializeField] private float _focusStep;
    [SerializeField] private float _focusDuration;
    [SerializeField] private Ease _focusEase;
    [SerializeField] private float _lastCameraFocus;
    [SerializeField] private float _lastCameraRotation;
    [SerializeField] private float _lastCameraRotationDuration;
    [SerializeField] private Ease _lastCameraFocusEase;
    [SerializeField] private float _lastCameraFocusDuration;

    private bool _activated;
    private Tween _idleTween;
    private Tween _pulseTween;
    private Tween _cameraRotationTween;
    private Tween _cameraFocusTween;

    public void ActivateConsumption()
    {
        _idleTween = transform.DOScale(_maxIdleScale, _idleDuration)
            .SetEase(_idleEase)
            .SetLoops(-1, LoopType.Yoyo);

        _activated = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_activated)
            return;

        if (!OilManager.Instance.TryDecreaseOil(_oilConsumtion, true))
            return;

        _oilProjectileAnimationSpawner.SpawnAnimation();
        _idleTween?.Kill(true);
        _idleTween = null;

        if(_pulseTween == null || !_pulseTween.IsPlaying()) 
            _pulseTween = transform.DOPunchScale(Vector3.one * _pulseScale, _pulseDuration).SetEase(_pulseEase);

        if (OilManager.Instance.OilCurrent == 0)
            EndMoonScene();
        else
            CameraFocus();
    }

    private void EndMoonScene()
    {
        _cameraRotationTween?.Kill();
        _cameraFocusTween?.Kill();

        _camera.transform.DORotate(new Vector3(0, 0, _lastCameraRotation), _lastCameraRotationDuration).SetEase(_lastCameraFocusEase);
        _cameraFocusTween = _camera.DOOrthoSize(_lastCameraFocus, _lastCameraFocusDuration).SetEase(_lastCameraFocusEase);
        _activated = false;
    }

    private void CameraFocus()
    {
        float rotation = 0;
        while (true)
        {
            rotation = Random.Range(_minRotation, _maxRotation);
            float delta = Mathf.Abs(Mathf.DeltaAngle(_camera.transform.eulerAngles.z, rotation));

            if (delta > _maxRotationStep || delta < _minRotationStep)
                continue;

            break;
        }

        _cameraRotationTween?.Kill();
        _cameraRotationTween = _camera.transform.DORotate(new Vector3(0, 0, rotation), _rotationDuration).SetEase(_rotationEase);

        _cameraFocusTween?.Kill();
        _cameraFocusTween = _camera.DOOrthoSize(_camera.orthographicSize - _focusStep, _focusDuration).SetEase(_focusEase);
    }
}
