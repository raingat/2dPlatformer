using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _countHeal;

    public float CountHeal => _countHeal;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
