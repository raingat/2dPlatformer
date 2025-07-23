using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimerVampirism : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = 1.0f;
        _slider.minValue = 0.0f;
    }

    private void OnEnable()
    {
        _vampirism.Activated += Activate;
        _vampirism.Deactivated += Recharge;
    }

    private void OnDisable()
    {
        _vampirism.Activated -= Activate;
        _vampirism.Deactivated -= Recharge;
    }

    private void Activate(float time)
    {
        float timeStep = _slider.maxValue / time;

        StartCoroutine(ActiveTimer(_slider.maxValue, _slider.minValue, timeStep));
    }

    private void Recharge(float time)
    {
        float timeStep = _slider.maxValue / time;

        StartCoroutine(ActiveTimer(_slider.minValue, _slider.maxValue, timeStep));
    }

    private IEnumerator ActiveTimer(float startPosition, float endPosition, float timeStep)
    {
        float step = 0.0f;

        while (_slider.value != endPosition)
        {
            step = Mathf.Clamp01(step += timeStep * Time.deltaTime);

            _slider.value = Mathf.Lerp(startPosition, endPosition, step);

            yield return null;
        }
    }
}
