using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerCreateButton : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private GameObject _spawner;

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
        _spawner.SetActive(true);
    }
}
