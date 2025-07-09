using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    [SerializeField] private int _capacity;
    [SerializeField] private int _maxSize;

    private ObjectPool<Coin> _pool;

    public int CountInactiveCoins => _pool.CountInactive;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>
            (
                createFunc: () => CreateFunc(),
                actionOnGet: (coin) => Get(coin),
                actionOnRelease: (coin) => Release(coin),
                actionOnDestroy: (coin) => Destroy(coin),
                collectionCheck: true,
                defaultCapacity: _capacity,
                maxSize: _maxSize
            );
    }

    public Coin OnGet()
    {
        Coin coin = _pool.Get();

        coin.Collected += OnRelease;

        return coin;
    }

    private void OnRelease(Coin coin)
    {
        coin.Collected -= OnRelease;

        _pool.Release(coin);
    }

    private Coin CreateFunc()
    {
        return Instantiate(_prefab);
    }

    private void Get(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }

    private void Release(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void Destroy(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}
