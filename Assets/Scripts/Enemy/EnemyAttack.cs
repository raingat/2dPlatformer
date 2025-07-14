using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _pointRaycast;

    [SerializeField] private float _damage;
    [SerializeField] private float _distance;
    [SerializeField] private float _waitTimeToAttack;

    [SerializeField] private LayerMask _layerMask;

    private Coroutine _coroutine;

    private RaycastHit2D _raycastHit;

    private void Update()
    {
        Debug.DrawRay(_pointRaycast.position, transform.right * _distance, Color.yellow);

        _raycastHit = Physics2D.Raycast(_pointRaycast.position, transform.right, _distance, _layerMask);

        if (_raycastHit.collider != null)
        {
            if (_raycastHit.transform.TryGetComponent(out IDamagable enemy) && _coroutine == null)
            {
                _coroutine = StartCoroutine(AttackEnemy(enemy));
            }
        }

        if (_raycastHit.collider == null && _coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }
    }

    private void Attack(IDamagable enemy)
    {
        enemy.TakeDamage(_damage);
    }

    private IEnumerator AttackEnemy(IDamagable enemy)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_waitTimeToAttack);

        while (enabled)
        {
            Attack(enemy);

            yield return waitForSeconds;
        }
    }
}
