using UnityEngine;

public class DisplayVampirismZone : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnOn()
    {
        _spriteRenderer.enabled = true;
    }

    public void TurnOff()
    {
        _spriteRenderer.enabled = false;
    }
}
