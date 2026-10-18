using UnityEngine;
using UnityEngine.EventSystems;

public class OilGiver : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _amount;
    [SerializeField] private Transform _rewardAnimationSpawnPoint;

    public void OnPointerClick(PointerEventData eventData) =>
        OilManager.Instance.AddOil(_amount, _rewardAnimationSpawnPoint.transform.position);
}