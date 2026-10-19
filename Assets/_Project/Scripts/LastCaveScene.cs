using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class LastCaveScene : MonoBehaviour
{
    [SerializeField] private float _sceneCameraX = 700;
    [SerializeField] private float _buttonNextDelay = 4f;
    [SerializeField] private GameObject _scene;
    [SerializeField] private Collider2D _goNextCollider;
    [SerializeField] private GameObject _text;

    private void Start()
    {
        _text.SetActive(false);
        _goNextCollider.enabled = false;
        DOVirtual.DelayedCall(_buttonNextDelay, ActivateButton);
    }

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

    private void ActivateButton()
    {
        _text.SetActive(true);
        _goNextCollider.enabled = true;
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
