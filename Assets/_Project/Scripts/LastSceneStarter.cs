using UnityEngine;
using UnityEngine.InputSystem;

public class LastSceneStarter : MonoBehaviour
{
    [SerializeField] private float _sceneCameraX = 600;
    [SerializeField] private GameObject _scene;

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
        gameObject.SetActive(false);
        Scene1();
    }

    private void Scene1()
    {
        _scene.SetActive(true);
        Camera camera = Camera.main;
        camera.transform.SetXPosition(_sceneCameraX);
    }
}
