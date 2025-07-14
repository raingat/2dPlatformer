using UnityEngine;

public class FirstAidKitCollector : MonoBehaviour
{
    [SerializeField] private Treate _hero;

    private ITreatment _treatment;

    private void Awake()
    {
        _treatment = _hero as ITreatment;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FirstAidKit firstAidKit))
        {
            _treatment.Treat(firstAidKit.CountHeal);

            firstAidKit.Destroy();
        }
    }
}
