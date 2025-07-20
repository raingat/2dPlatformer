using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    private float _currentHealth;

    public event Action<GameObject> Died;
    public event Action<float> HealthChanged;

    public bool IsDied => _currentHealth <= _minHealth;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            damage = 0;

        _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);

        if (IsDied)
            Died?.Invoke(gameObject);

        HealthChanged?.Invoke(_currentHealth);
    }

    public void Treat(float countHeal)
    {
        if (countHeal < 0)
            countHeal = 0;

        _currentHealth = Mathf.Clamp(_currentHealth += countHeal, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }
}
