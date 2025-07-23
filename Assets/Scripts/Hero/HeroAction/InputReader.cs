using UnityEngine;

public class InputReader
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly int NumberMouseButton = 0;
    private readonly KeyCode KeyCodeToVampirism = KeyCode.E;

    public float GetHorizontalDirection()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool IsJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool IsAttack()
    {
        return Input.GetMouseButtonDown(NumberMouseButton);
    }

    public bool IsVampirism()
    {
        return Input.GetKeyDown(KeyCodeToVampirism);
    }
}
