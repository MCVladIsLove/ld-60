using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private OilGeyser _startGeyser;
    [SerializeField] private float _cameraStartYPosition = 8;
    [SerializeField] private float _cameraEndYPosition = 0;
    [SerializeField] private float _cameraMoveDuration = 2;
    [SerializeField] private Ease _cameraMoveEase = Ease.InCirc;
    [SerializeField] private float _oilStartDelay = 3;
    [SerializeField] private float _smileDelay = 6;
    [SerializeField] private float _smileCameraX = 35;
    [SerializeField] private float _smileActiveTime = 3.5f;
    [SerializeField] private GameObject _smilePanel;
    [SerializeField] private GameObject _storage;
    [SerializeField] private GameObject _collectText;
    [SerializeField] private GameObject _updateButton;

    private void Awake()
    {
        Camera camera = Camera.main;
        camera.transform.SetYPosition(_cameraStartYPosition);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        Camera camera = Camera.main;
        camera.transform.DOMoveY(_cameraEndYPosition, _cameraMoveDuration).SetEase(_cameraMoveEase);

        DOVirtual.DelayedCall(_oilStartDelay, StartGeyser);
        DOVirtual.DelayedCall(_smileDelay, ShowSmile);
    }

    private void StartGeyser() =>
        _startGeyser.gameObject.SetActive(true);

    private void ShowSmile()
    {
        _smilePanel.SetActive(true);

        Camera camera = Camera.main;
        camera.transform.SetXPosition(_smileCameraX);
        DOVirtual.DelayedCall(_smileActiveTime, BringCameraBack);
    }

    private void BringCameraBack()
    {
        _storage.SetActive(true);
        _smilePanel.SetActive(false);
        _collectText.SetActive(true);
        _updateButton.SetActive(true);

        Camera camera = Camera.main;
        camera.transform.SetXPosition(0);
    }
}
