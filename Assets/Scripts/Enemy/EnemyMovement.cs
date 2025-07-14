using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform _pointRaycast;

    [SerializeField] private float _distance;

    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D _raycastHit;

    public event Action<float> Patrolling;
    public event Action<Vector2, float> Following;

    private void Update()
    {
        if (_raycastHit.collider == null)
        {
            Patrolling?.Invoke(_speed);
        }
        else
        {
            Following?.Invoke(_raycastHit.transform.position, _speed);
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(_pointRaycast.position, transform.right * _distance, Color.red);

        _raycastHit = Physics2D.Raycast(_pointRaycast.position, transform.right, _distance, _layerMask);
    }
}
