using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    [SerializeField] private EnemyAnimation _enemyAnimation;

    [SerializeField] private EnemyMovement _movement;

    private int _currentWayPoint = 0;

    private bool _isRunning = false;

    private void OnEnable()
    {
        _movement.Patrolling += Move;
    }

    private void OnDisable()
    {
        _movement.Patrolling -= Move;
    }

    private void Move(float speed)
    {
        if (transform.position.x == _wayPoints[_currentWayPoint].position.x)
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;

        Vector2 target = Vector2.one * new Vector2(_wayPoints[_currentWayPoint].position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Rotate(target.x);

        _isRunning = true;

        _enemyAnimation.PlayAnimationRun(_isRunning);
    }

    private void Rotate(float xCoordinateTarget)
    {
        float degreesRotate;

        if (xCoordinateTarget > transform.position.x)
        {
            degreesRotate = 0.0f;

            transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
        }
        else
        {
            degreesRotate = 180.0f;

            transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
        }
    }
}
