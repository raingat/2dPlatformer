using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected void OnEnable()
    {
        Health.HealthChanged += ChangeValue;
    }

    protected void OnDisable()
    {
        Health.HealthChanged -= ChangeValue;
    }

    protected abstract void ChangeValue(float currentHealth);
}
