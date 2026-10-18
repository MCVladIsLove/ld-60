using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WellUpgradeButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _upgradeText;
    [SerializeField] private int _upgradeCost;
    [SerializeField] private GameObject _nextWell;
    [SerializeField] private GameObject _thisWell;

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
                _thisWell.SetActive(false);
                _nextWell.SetActive(true);
            }
        }
    }
}