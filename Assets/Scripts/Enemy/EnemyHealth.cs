using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float _health;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (IsDied())
            Destroy(gameObject);
    }

    private bool IsDied()
    {
        return _currentHealth <= 0;
    }
}
