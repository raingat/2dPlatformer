using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private AnimationHero _animation;

    private Rigidbody2D _rigidbody;

    private InputReader _inputReader = new();

    private bool _canJump;
    private bool _isRunning;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out TilemapCollider2D collider))
        {
            _canJump = true;
        }
    }

    private void Move()
    {
        float direction = _inputReader.GetHorizontalDirection();

        float distance = direction * _speed * Time.deltaTime;

        _isRunning = CanMove(direction);

        Rotate(direction);

        transform.Translate(distance * Vector2.right, Space.World);

        _animation.PlayAnimationRun(_isRunning);
    }

    private bool CanMove(float direction)
    {
        float stand = 0.0f;

        return direction != stand;
    }

    private void Rotate(float direction)
    {
        float degreesRotate;

        if (direction < 0.0f)
        {
            degreesRotate = 180.0f;

            transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
        }
        else
        {
            degreesRotate = 0.0f;

            transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
        }
    }

    private void Jump()
    {
        if (_inputReader.IsSpaceDown() && _canJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            _canJump = false;
        }
    }
}
