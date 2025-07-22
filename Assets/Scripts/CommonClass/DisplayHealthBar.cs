using UnityEngine;

public class DisplayHealthBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void Update()
    {
        _canvas.transform.position = transform.position;
    }
}
