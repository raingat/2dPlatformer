using UnityEngine;

public class InputReader
{
    private readonly string Horizontal = nameof(Horizontal);

    public float GetHorizontalDirection()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool IsSpaceDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
