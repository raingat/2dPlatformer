using UnityEngine;

public class Treate : MonoBehaviour, ITreatment
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Treat(float countHeal)
    {
        _health.Treat(countHeal);
    }
}
