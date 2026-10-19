using UnityEngine;

public class OilProjectileAnimation : MonoBehaviour
{
    [SerializeField] private float _minSize = 0.35f;
    [SerializeField] private float _maxSize = 0.45f;

    public void Init()
    {
        transform.localScale = Vector3.one * Random.Range(_minSize, _maxSize);
        transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));
    }
}