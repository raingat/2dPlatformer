using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] private Transform _pointRaycast;

    [SerializeField] private float _damage;

    [SerializeField] private float _distance;

    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D _raycastHit;

    private InputReader _inputReader = new();

    private void Update()
    {
        Debug.DrawRay(_pointRaycast.position, transform.right * _distance, Color.yellow);

        if (_inputReader.IsAttack())
            Attack();
    }

    private void Attack()
    {
        _raycastHit = Physics2D.Raycast(_pointRaycast.position, transform.right, _distance, _layerMask);

        if (_raycastHit.collider != null)
        {
            if (_raycastHit.transform.TryGetComponent(out IDamagable enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }
    }
}
