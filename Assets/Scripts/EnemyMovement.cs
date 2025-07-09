using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _wayPoints;

    private SpriteRenderer _spriteRenderer;

    private int _currentWayPoint = 0;

    private bool _isRunning = false;

    public event Action<bool> Running;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x == _wayPoints[_currentWayPoint].position.x)
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;

        Vector2 target = Vector2.one * new Vector2(_wayPoints[_currentWayPoint].position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (target.x > transform.position.x)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;

        _isRunning = true;

        Running?.Invoke(_isRunning);
    }
}
