using UnityEngine;

public class HeroHealth : MonoBehaviour, IDamagable, ITreatment
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

        Debug.Log(_currentHealth);
    }

    public void Treat(float countHeal)
    {
        _currentHealth += countHeal;

        if (_currentHealth > _health)
            _currentHealth = _health;

        Debug.Log(_currentHealth);
    }

    private bool IsDied()
    {
        return _currentHealth <= 0;
    }
}
