using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _health;

    private float _currentHealth;

    public event Action<GameObject> Died;

    private void Awake()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (IsDied())
            Died?.Invoke(gameObject);
    }

    public void Treat(float countHeal)
    {
        _currentHealth += countHeal;

        if (_currentHealth > _health)
            _currentHealth = _health;
    }

    private bool IsDied()
    {
        return _currentHealth <= 0;
    }
}
