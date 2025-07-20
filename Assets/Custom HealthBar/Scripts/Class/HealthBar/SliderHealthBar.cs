using UnityEngine.UI;

public class SliderHealthBar : HealthBar
{
    protected Slider _slider;

    protected void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void ChangeValue(float currentHealth)
    {
        _slider.value = currentHealth / Health.MaxHealth;
    }
}
