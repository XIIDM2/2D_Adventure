using UnityEngine;

public class UnitGroundMovement : MonoBehaviour, IMovable
{
    [Header("Movement")]
    [SerializeField] private float _movementSpeed = 5.0f;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 5.0f;

    [Header("GroundLogic")]
    public bool IsGrounded { get; private set; }

    [SerializeField] private float _groundCheckOffset = 0.05f;

    private int _groundLayer;

    private BoxCollider2D _collider;

    private Rigidbody2D _rb;
    private ObjectDirection _objectDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _objectDirection = new ObjectDirection();

        _groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        _objectDirection.FaceDirection(transform, _rb.linearVelocityX);
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0.0f, Vector2.down, _groundCheckOffset, _groundLayer);
    }

    public void Move(Vector2 vector)
    {
        _rb.linearVelocityX = vector.x * _movementSpeed;
    }

    public void Jump()
    {
       if (IsGrounded) _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(_collider.bounds.center + Vector3.down * _groundCheckOffset, _collider.bounds.size);
    }
}
