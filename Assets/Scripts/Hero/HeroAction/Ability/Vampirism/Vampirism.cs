using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _workTime;
    [SerializeField] private float _rechargeTime;

    [SerializeField] private float _numberReturnHealth;

    [SerializeField] private TargetSearcher _targetSearcher;

    [SerializeField] private DisplayVampirismZone _zone;

    private Health _treate;

    private InputReader _inputReader = new();

    private Coroutine _coroutine;

    private bool _canActivate = true;

    public event Action<float> Activated;
    public event Action<float> Deactivated;

    private void Awake()
    {
        _treate = GetComponent<Health>();
    }

    private void Update()
    {
        if (_inputReader.IsVampirism() && _canActivate)
            StartCoroutine(TurnOnTimer(_workTime));
    }

    private void StealHealth(Collider2D colliderTarget)
    {
        if (colliderTarget != null)
        {
            if (colliderTarget.transform.TryGetComponent(out IDamagable target))
            {
                target.TakeDamage(_numberReturnHealth);

                _treate.Treat(_numberReturnHealth);
            }
        }
    }

    private void ActivateAbility()
    {
        _canActivate = false;

        _coroutine = StartCoroutine(LaunchAbility());

        _zone.TurnOn();

        Activated?.Invoke(_workTime);
    }

    private void DeactivateAbility()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }

        _zone.TurnOff();

        Deactivated?.Invoke(_rechargeTime);
    }

    private IEnumerator TurnOnTimer(float time)
    {
        WaitForSeconds workTime = new WaitForSeconds(_workTime);
        WaitForSeconds rechargeTime = new WaitForSeconds(_rechargeTime);

        ActivateAbility();

        yield return workTime;

        DeactivateAbility();

        yield return rechargeTime;

        _canActivate = true;
    }

    private IEnumerator LaunchAbility()
    {
        while (enabled)
        {
            StealHealth(_targetSearcher.Locate());

            yield return null;
        }
    }
}

