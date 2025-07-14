using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;

    private void OnEnable()
    {
        _movement.Following += MoveToTarget;
    }


    private void OnDisable()
    {
        _movement.Following -= MoveToTarget;
    }

    private void MoveToTarget(Vector2 positionTarget, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, positionTarget, speed * Time.deltaTime);
    }
}
