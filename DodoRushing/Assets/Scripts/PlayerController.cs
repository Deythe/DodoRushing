using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerData _data;
    [SerializeField] private LayerMask groundLayerMask;
    private RaycastHit2D hit;
    private Vector2 _direction;
    private PlayerInputs _inputs;
    private bool _isGrounded, doubleJumped, dashInCooldown, _isDashing;
    private float timerDash;

    private void Start()
    {
        _inputs = new PlayerInputs();
        _inputs.Enable();
        _direction = Vector2.right * _data.speedMovement;
    }

    private void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _data.height, groundLayerMask);
        
        if (!_isDashing)
        {
            _direction = new Vector2(_data.speedMovement, _rb.velocity.y + _data.gravity);
        }

        if (_inputs.Movements.Dash.WasPerformedThisFrame() && !dashInCooldown)
        {
            Debug.Log("test");
            StartCoroutine(CoroutineDash());
        }

        if (_inputs.Movements.Jump.WasPerformedThisFrame())
        {
            Jump();
        }

        if (_isGrounded && doubleJumped)
        {
            doubleJumped = false;
        }
        
        if (_inputs.Movements.Jump.IsPressed() && _direction.y<0)
        {
            _direction.y /= 1.02f;
        }
        
        _rb.velocity = _direction;
    }

    void Jump()
    {
        if (_isGrounded)
        {
            _direction = new Vector2(_direction.x, _data.jumpForce);
        }
        else
        {
            if (!doubleJumped)
            {
                _direction = new Vector2(_direction.x, _data.jumpForce);
                doubleJumped = true;
            }
        }
    }

    IEnumerator CoroutineDash()
    {
        timerDash = _data.durationDash;
        _isDashing = true;
        dashInCooldown = true;
        
        do
        {
            _direction.x += _data.dashForce;
            timerDash-=0.1f;
            yield return new WaitForEndOfFrame();
        } while (timerDash > 0);
        
        _isDashing = false;
        StartCoroutine(CoroutineCooldownDash());
    }

    IEnumerator CoroutineCooldownDash()
    {
        yield return new WaitForSeconds(_data.cooldownDash);
        dashInCooldown = false;
    }
}
