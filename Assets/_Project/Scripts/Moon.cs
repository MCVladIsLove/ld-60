using UnityEngine;
using UnityEngine.EventSystems;

public class Moon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _oilConsumtion = 100;
    [SerializeField] private int _oilNeeded = 5000;
    [SerializeField] private OilProjectileAnimationSpawner _oilProjectileAnimationSpawner;

    private bool _activated;

    public void ActivateConsumption() =>
        _activated = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_activated)
            return;

        OilManager.Instance.DecreaseOil(_oilConsumtion, true);
        _oilProjectileAnimationSpawner.SpawnAnimation();
    }
}
