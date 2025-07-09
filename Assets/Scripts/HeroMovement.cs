using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroMovement : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);

    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private bool _canJump = false;
    private bool _isRunning = false;

    public event Action<bool> Running;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        float direction = Input.GetAxis(Horizontal);

        if (direction == 0.0f)
        {
            _isRunning = false;
        }
        else
        {
            _isRunning = true;

            if (direction < 0.0f)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }

        float distance = direction * _speed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);

        Running?.Invoke(_isRunning);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            _canJump = false;
        }
    }
}
