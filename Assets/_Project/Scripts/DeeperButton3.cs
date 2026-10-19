using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeeperButton3 : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private Moon _moon;
    [SerializeField] private float _moonX = 0.29f;
    [SerializeField] private float _moonY = 1.5f;
    [SerializeField] private float _moonMoveTime = 1.5f;
    [SerializeField] private Ease _moonMoveEase;

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
        OilManager.Instance.DisableOil();
        gameObject.SetActive(false);

        _moon.transform.DOMove(new Vector3(_moonX, _moonY, _moon.transform.position.z), _moonMoveTime)
            .SetEase(_moonMoveEase)
            .OnComplete(_moon.ActivateConsumption);
    }
}
