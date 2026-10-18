using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private GameObject _spriteMask;
    [SerializeField] private float _maskMinPos;
    [SerializeField] private float _maskMaxPos;
    [SerializeField] private int _maxOil;
    [SerializeField] private TMP_Text _fillAmount;
    [SerializeField] private Storage _nextStorageLevel;
    [SerializeField] private StorageUpgradeButton _upgradeButton;

    public void SetOil(int oilAmount)
    {
        _fillAmount.text = $"{oilAmount}/{_maxOil}";
        float normalized = oilAmount / (float)_maxOil;
        _spriteMask.transform.SetYLocalPosition(_maskMinPos + (_maskMaxPos - _maskMinPos) * normalized);
    }

    public void Upgrade()
    {
        gameObject.SetActive(false);
        _nextStorageLevel.gameObject.SetActive(true);
        _nextStorageLevel.SetOil(OilManager.Instance.OilCurrent);
    }
}
