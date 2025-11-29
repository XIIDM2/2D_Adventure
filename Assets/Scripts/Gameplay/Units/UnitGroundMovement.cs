using UnityEngine;

public class UnitGroundMovement : MonoBehaviour, IMoveable, IJumpable
{
    [Header("Parameters")]
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;

    [Header("GroundCollisionCheck")]
    [SerializeField] private Transform _groundCollision;
    [SerializeField] private Vector2 _groundCollisionSize;

    private LayerMask _groundLayer;
    private Rigidbody2D _rb;

    private IMovementContext _movementcontext;
    private ObjectDirection _direction;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movementcontext = GetComponent<IMovementContext>();

        _direction = new ObjectDirection();
    }

    private void Start()
    {
        _groundLayer = LayerMask.GetMask("Ground");
    }


    private void FixedUpdate()
    {
        _movementcontext.SetGroundedStatus(Physics2D.OverlapBox(_groundCollision.position, _groundCollisionSize, 0.0f, _groundLayer));
    }

    public void Move(Vector2 direction)
    {
        _rb.linearVelocityX = Mathf.Clamp(direction.x * _movementSpeed, -_movementSpeed, _movementSpeed);

        _direction.FaceDirection(transform, _rb.linearVelocityX);
    }

    public void Jump()
    {
        _rb.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundCollision.position, _groundCollisionSize);
    }
}
