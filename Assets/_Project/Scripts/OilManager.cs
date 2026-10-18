using UnityEngine;

public class OilManager : MonoBehaviour
{
    [SerializeField] private Storage[] _storages;
    [SerializeField] private OilCollectAnimationSpawner _oilAnimationSpawner;

    private int _oilCurrent;
    private bool _disabled;

    public int OilCurrent => _oilCurrent;
    public static OilManager Instance;


    private void Awake() =>
        Instance = this;

    public void AddOil(int oil, Vector3 position)
    {
        if (_disabled)
            return;

        foreach (Storage storage in _storages)
        {
            if (!storage.gameObject.activeInHierarchy) 
                continue;

            int newOilAmount = Mathf.Clamp(_oilCurrent + oil, _oilCurrent + oil, storage.MaxOil);
            if (newOilAmount == _oilCurrent)
                return;

            int diff = newOilAmount - _oilCurrent;
            _oilCurrent = newOilAmount;
            storage.SetOil(_oilCurrent);
            _oilAnimationSpawner.SpawnCollectAnimation(diff, position);

            return;
        }
    }

    public void DecreaseOil(int oil, bool force = false)
    {
        if (_disabled && !force)
            return;

        if (_oilCurrent - oil < 0)
            return;

        _oilCurrent -= oil;
        foreach (Storage storage in _storages)
        {
            if (!storage.gameObject.activeInHierarchy)
                continue;

            storage.SetOil(_oilCurrent);
            return;
        }
    }

    public void DisableOil() =>
        _disabled = true;
}