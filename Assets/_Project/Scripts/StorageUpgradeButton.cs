using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StorageUpgradeButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _upgradeText;
    [SerializeField] private int _upgradeCost;
    [SerializeField] private Storage _storage;

    private void Awake()
    {
        _upgradeText.text = $"-{_upgradeCost} UP";
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
            if (OilManager.Instance.OilCurrent >= _upgradeCost)
            {
                OilManager.Instance.TryDecreaseOil(_upgradeCost);
                _storage.Upgrade();
            }
        }
    }
}
