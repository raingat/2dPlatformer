using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private HeroWallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Collect();

            _wallet.CollectCoin();
        }
    }
}
