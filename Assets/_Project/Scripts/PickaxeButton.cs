using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeButton : MonoBehaviour
{
    [SerializeField] private float _sceneCameraX = 500;
    [SerializeField] private float _sceneActiveTime = 4f;
    [SerializeField] private GameObject _pickaxe;
    [SerializeField] private GameObject _scene;
    [SerializeField] private GameObject _nextButton;

    private void Update()
    {
        if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame)
            return;

        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            DoSmth();
        }
    }

    private void DoSmth()
    {
        _pickaxe.SetActive(false);
        gameObject.SetActive(false);
        Scene1();
    }

    private void Scene1()
    {
        _scene.SetActive(true);
        Camera camera = Camera.main;
        camera.transform.SetXPosition(_sceneCameraX);
        DOVirtual.DelayedCall(_sceneActiveTime, End);
    }

    private void End()
    {
        _scene.SetActive(false);
        _nextButton.SetActive(true);
        Camera camera = Camera.main;
        camera.transform.SetXPosition(0);
    }
}