using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _workTime;
    [SerializeField] private float _rechargeTime;

    [SerializeField] private float _radiusAction;

    [SerializeField] private float _numberReturnHealth;

    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private DisplayVampirismZone _zone;

    private Health _treate;

    private InputReader _inputReader = new();

    private bool _canActivate = true;
    private bool _isActivate = false;

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

        if (_isActivate)
            StealHealth(SearchTarget());
    }

    private Collider2D SearchTarget()
    {
        Collider2D colliderTarget = Physics2D.OverlapCircle(transform.position, _radiusAction, _layerMask);

        return colliderTarget;
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

        _isActivate = true;

        _zone.TurnOn();

        Activated?.Invoke(_workTime);
    }

    private void DeactivateAbility()
    {
        _isActivate = false;

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
}

