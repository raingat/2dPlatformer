using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += DestroyPerson;
    }

    private void OnDisable()
    {
        _health.Died -= DestroyPerson;
    }

    private void DestroyPerson(GameObject character)
    {
        Destroy(character);
    }
}
