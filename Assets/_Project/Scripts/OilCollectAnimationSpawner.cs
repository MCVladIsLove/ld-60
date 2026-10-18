using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OilCollectAnimationSpawner : MonoBehaviour
{
    [SerializeField] private OilAnimation _animationPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private float _flyTime;
    [SerializeField] private float _flyHeight;
    [SerializeField] private Ease _flyEase;
    [SerializeField] private float _spawnRange;

    private List<OilAnimation> _pool = new();

    private void Awake()
    {
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));
        _pool.Add(Instantiate(_animationPrefab, _container));

        foreach (OilAnimation oil in _pool)
            oil.gameObject.SetActive(false);
    }

    public void SpawnCollectAnimation(int oilAmount, Vector3 position)
    {
        OilAnimation animation = _pool.FirstOrDefault();
        if (animation == null)
            animation = Instantiate(_animationPrefab, _container);
        else
            _pool.RemoveAt(0);

        animation.gameObject.SetActive(true);
        animation.SetAmount(oilAmount);

        Vector2 shift = Random.insideUnitCircle * _spawnRange;
        animation.transform.position = new Vector2(position.x + shift.x, position.y + shift.y);

        animation.transform.DOMoveY(animation.transform.position.y + _flyHeight, _flyTime).SetEase(_flyEase)
            .OnComplete(() => ReleaseAnimation(animation));
    }

    private void ReleaseAnimation(OilAnimation animation)
    {
        animation.gameObject.SetActive(false);
        _pool.Add(animation);
    }
}