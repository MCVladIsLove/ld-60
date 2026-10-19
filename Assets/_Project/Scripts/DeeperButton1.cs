using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeeperButton1 : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private float _sceneDelay = 1;
    [SerializeField] private float _animDelay = 3;
    [SerializeField] private Animator _animation;
    [SerializeField] private float _sceneCameraX = 100;
    [SerializeField] private float _sceneActiveTime = 4f;
    [SerializeField] private GameObject _scene;
    [SerializeField] private float _scene2CameraX = 100;
    [SerializeField] private float _scene2ActiveTime = 4f;
    [SerializeField] private GameObject _scene2;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _well;
    [SerializeField] private GameObject _oil;
    [SerializeField] private GameObject _spawnerBtn;

    private void Update()
    {
        if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame)
            return;

        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (OilManager.Instance.OilCurrent >= _cost)
            {
                DoSmth();
            }
        }
    }

    private void DoSmth()
    {
        OilManager.Instance.TryDecreaseOil(_cost);

        gameObject.SetActive(false);
        _oil.SetActive(false);
        _well.SetActive(true);

        DOVirtual.DelayedCall(_sceneDelay, Scene1);
    }

    private void Scene1()
    {
        _spawnerBtn.SetActive(true);
        _scene.SetActive(true);
        Camera camera = Camera.main;
        camera.transform.SetXPosition(_sceneCameraX);
        DOVirtual.DelayedCall(_sceneActiveTime, Scene2);

    }

    private void Scene2()
    {
        _scene.SetActive(false);
        _scene2.SetActive(true);

        Camera camera = Camera.main;
        camera.transform.SetXPosition(_scene2CameraX);
        DOVirtual.DelayedCall(_animDelay, Anim);

    }

    private void Anim()
    {
        _animation.enabled = true;
        DOVirtual.DelayedCall(_scene2ActiveTime, End);
    }

    private void End()
    {
        _scene2.SetActive(false);
        _nextButton.SetActive(true);
        Camera camera = Camera.main;
        camera.transform.SetXPosition(0);
    }
}
