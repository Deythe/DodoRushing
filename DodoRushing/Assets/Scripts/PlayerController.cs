using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerData _data;
    [SerializeField] private LayerMask groundLayerMask;
    private RaycastHit2D hit;
    private Vector2 _direction;
    private PlayerInputs _inputs;
    private bool _isGrounded;

    private void Start()
    {
        _inputs = new PlayerInputs();
        _inputs.Enable();
        _direction = Vector2.right;
    }

    private void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _data.height, groundLayerMask);
        _direction = new Vector2(_direction.x, _rb.velocity.y);
        
        if (_inputs.Movements.Jump.WasPerformedThisFrame() && _isGrounded)
        {
            _direction += Vector2.up * _data.jumpForce;
        }
        _rb.velocity = _direction;
    }
}
