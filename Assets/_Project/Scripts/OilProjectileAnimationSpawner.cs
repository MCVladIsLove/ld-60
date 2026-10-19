using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OilProjectileAnimationSpawner : MonoBehaviour
{
    [SerializeField] private OilProjectileAnimation _animationPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private float _flyTime;
    [SerializeField] private Ease _flyEase;
    [SerializeField] private float _spawnRange;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Moon _moon;

    private List<OilProjectileAnimation> _pool = new();

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

        foreach (OilProjectileAnimation oil in _pool)
            oil.gameObject.SetActive(false);
    }

    public void SpawnAnimation()
    {
        OilProjectileAnimation animation = _pool.FirstOrDefault();
        if (animation == null)
            animation = Instantiate(_animationPrefab, _container);
        else
            _pool.RemoveAt(0);

        animation.Init();
        animation.gameObject.SetActive(true);

        Vector2 shift = Random.insideUnitCircle * _spawnRange;
        animation.transform.position = new Vector2(_spawnPoint.position.x + shift.x, _spawnPoint.position.y + shift.y);

        animation.transform.DOMove(_moon.transform.position, _flyTime).SetEase(_flyEase)
            .OnComplete(() => ReleaseAnimation(animation));
    }

    private void ReleaseAnimation(OilProjectileAnimation animation)
    {
        animation.gameObject.SetActive(false);
        _pool.Add(animation);
    }
}
