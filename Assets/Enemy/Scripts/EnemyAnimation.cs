using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationRun(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }
}
