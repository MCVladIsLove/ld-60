using UnityEngine;

public class CollectText : MonoBehaviour
{
    [SerializeField] private OilGiver _oil;

    private void OnEnable() =>
        _oil.OnOilCollected += DisableThis;

    private void OnDisable() =>
        _oil.OnOilCollected -= DisableThis;

    private void DisableThis() =>
        gameObject.SetActive(false);
}