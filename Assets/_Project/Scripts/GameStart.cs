using DG.Tweening;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private OilGeyser _startGeyser;
    [SerializeField] private float _cameraStartYPosition = 8;
    [SerializeField] private float _cameraEndYPosition = 0;
    [SerializeField] private float _cameraMoveDuration = 2;
    [SerializeField] private Ease _cameraMoveEase = Ease.InCirc;
    [SerializeField] private float _oilStartDelay = 3;

    private void Awake()
    {
        Camera camera = Camera.main;
        camera.transform.SetYPosition(_cameraStartYPosition);
    }

    private void Start()
    {
        Camera camera = Camera.main;
        camera.transform.DOMoveY(_cameraEndYPosition, _cameraMoveDuration).SetEase(_cameraMoveEase);

        DOVirtual.DelayedCall(_oilStartDelay, StartGeyser);
    }

    private void StartGeyser() =>
        _startGeyser.gameObject.SetActive(true);
}