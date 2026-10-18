using TMPro;
using UnityEngine;

public class OilAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountText;

    public void SetAmount(int amount) =>
        _amountText.text = $"+{amount}";
}