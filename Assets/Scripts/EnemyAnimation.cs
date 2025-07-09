using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private readonly string IsRunning = "isRunning";

    [SerializeField] private EnemyMovement _enemyMovement;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemyMovement.Running += PlayAnimationRun;
    }

    private void OnDisable()
    {
        _enemyMovement.Running -= PlayAnimationRun;
    }

    private void PlayAnimationRun(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }
}
