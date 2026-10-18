using UnityEngine;

public class OilManager : MonoBehaviour
{
    private int _oilCurrent;

    public int OilCurrent => _oilCurrent;
    public static OilManager Instance;


    private void Awake() =>
        Instance = this;
}