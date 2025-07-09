using UnityEngine;

public class AnimationHero : MonoBehaviour
{
    private readonly string IsRunning = "isRunning";

    [SerializeField] private HeroMovement _heroMovement;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _heroMovement.Running += PlayAnimationRun;
    }

    private void OnDisable()
    {
        _heroMovement.Running -= PlayAnimationRun;
    }

    private void PlayAnimationRun(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }
}
