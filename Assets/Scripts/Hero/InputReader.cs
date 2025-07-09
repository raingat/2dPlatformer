using UnityEngine;

public class InputReader
{
    private readonly string Horizontal = nameof(Horizontal);

    public float GetHorizontalDirection()
    {
        return Input.GetAxis(Horizontal);
    }
}
