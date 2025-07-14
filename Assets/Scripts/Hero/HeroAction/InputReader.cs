using UnityEngine;

public class InputReader
{
    private readonly string Horizontal = nameof(Horizontal);

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
        int numberMouseButton = 0;

        return Input.GetMouseButtonDown(numberMouseButton);
    }
}
