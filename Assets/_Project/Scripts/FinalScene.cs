using DG.Tweening;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private float _oil1Delay = 2.5f;
    [SerializeField] private float _oil2Delay = 3.5f;
    [SerializeField] private float _oil3Delay = 4.75f;
    [SerializeField] private float _oil4Delay = 5.25f;
    [SerializeField] private float _oil5Delay = 6f;
    [SerializeField] private float _endDelay;
    [SerializeField] private float _oilStartDelay;
    [SerializeField] private float _oilDuration = 10;
    [SerializeField] private GameObject _theEndText;
    [SerializeField] private GameObject _oilBlock;
    [SerializeField] private float _oilStart;
    [SerializeField] private float _oilEnd;
    [SerializeField] private GameObject _oil1;
    [SerializeField] private GameObject _oil2;
    [SerializeField] private GameObject _oil3;
    [SerializeField] private GameObject _oil4;
    [SerializeField] private GameObject _oil5;

    private void Start()
    {
        _oilBlock.transform.SetYLocalPosition(_oilStart); 
        _theEndText.SetActive(false);
        DOVirtual.DelayedCall(_endDelay, TheEnd);
        DOVirtual.DelayedCall(_oil1Delay, StartOil1);
        DOVirtual.DelayedCall(_oil2Delay, StartOil2);
        DOVirtual.DelayedCall(_oil3Delay, StartOil3);
        DOVirtual.DelayedCall(_oil4Delay, StartOil4);
        DOVirtual.DelayedCall(_oil5Delay, StartOil5);
        DOVirtual.DelayedCall(_oilStartDelay, OilBlockMove);
    }

    private void TheEnd()
    {
        _theEndText.SetActive(true);
    }

    private void StartOil1() =>
        _oil1.SetActive(true);
    
    private void StartOil2() =>
        _oil2.SetActive(true);
    
    private void StartOil3() =>
        _oil3.SetActive(true);
    
    private void StartOil4() =>
        _oil4.SetActive(true);
    
    private void StartOil5() =>
        _oil5.SetActive(true);

    private void OilBlockMove()
    {
        _oilBlock.transform.DOLocalMoveY(_oilEnd, _oilDuration);
    }
}