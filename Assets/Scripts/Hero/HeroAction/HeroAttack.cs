using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private InputReader _inputReader = new();

    private void Update()
    {
        if (_inputReader.IsAttack() && _weapon.CanAttack)
            _weapon.Attack();
    }
}
