using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinPool _pool;

    [SerializeField] private float _waitTime;

    private bool _canSpawn = true;

    private void Awake()
    {
        Spawn();
    }

    private void Update()
    {
        if (_pool.CountInactiveCoins != 0)
        {
            _canSpawn = true;

            Invoke(nameof(Spawn), _waitTime);
        }
    }

    private void Spawn()
    {
        if (_canSpawn)
        {
            Coin coin = _pool.OnGet();

            coin.transform.position = transform.position;

            _canSpawn = false;
        }
    }
}
