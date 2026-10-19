using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OilGiver : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _amount;
    [SerializeField] private Transform _rewardAnimationSpawnPoint;

    public event Action OnOilCollected;

    public void OnPointerClick(PointerEventData eventData)
    {
        Collect();
    }

    public void Collect()
    {
        if (!gameObject.activeInHierarchy)
            return;

        OilManager.Instance.AddOil(_amount, _rewardAnimationSpawnPoint.transform.position);
        OnOilCollected?.Invoke();
    }
}