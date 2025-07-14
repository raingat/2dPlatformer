using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _wayPoints;

    [SerializeField] private EnemyAnimation _enemyAnimation;

    [SerializeField] private Transform _pointRaycast;

    [SerializeField] private float _distance;

    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D _raycastHit;

    private int _currentWayPoint = 0;

    private bool _isRunning = false;

    private void Update()
    {
        Debug.DrawRay(_pointRaycast.position, transform.right * _distance, Color.red);

        _raycastHit = Physics2D.Raycast(_pointRaycast.position, transform.right, _distance, _layerMask);

        if (_raycastHit.collider == null)
        {
            Move();
        }
        else
        {
            MoveToTarget(_raycastHit.transform.position);
        }
    }

    private void MoveToTarget(Vector2 positionTarget)
    {
        transform.position = Vector2.MoveTowards(transform.position, positionTarget, _speed * Time.deltaTime);
    }

    private void Move()
    {
        if (transform.position.x == _wayPoints[_currentWayPoint].position.x)
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;

        Vector2 target = Vector2.one * new Vector2(_wayPoints[_currentWayPoint].position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

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
