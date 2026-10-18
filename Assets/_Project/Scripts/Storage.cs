using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private GameObject _spriteMask;
    [SerializeField] private float _maskMinPos;
    [SerializeField] private float _maskMaxPos;

    public void SetFill(float value) =>
        _spriteMask.transform.SetYLocalPosition(_maskMinPos + (_maskMaxPos - _maskMinPos) * value);
}