using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _pointRaycast;

    [SerializeField] private float _damage;

    [SerializeField] private float _distance;

    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D _raycastHit;

    private bool _canAttack;

    public bool CanAttack => _canAttack;

    private void FixedUpdate()
    {
        Debug.DrawRay(_pointRaycast.position, transform.right * _distance, Color.yellow);

        _raycastHit = Physics2D.Raycast(_pointRaycast.position, transform.right, _distance, _layerMask);

        if (_raycastHit.collider != null)
        {
            _canAttack = true;
        }
        else
        {
            _canAttack = false;
        }
    }

    public void Attack()
    {
        if (_raycastHit.transform.TryGetComponent(out IDamagable enemy))
            enemy.TakeDamage(_damage);
    }
}
