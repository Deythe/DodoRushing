using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerData _data;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private UnityEvent dropEgg;
    [SerializeField] private Animator animator;
    
    private RaycastHit2D hit;
    private Vector2 _direction, _dashDir = Vector2.right;
    private bool _isGrounded, doubleJumped, dashInCooldown, _isDashing, _onASlide;
    private float _timerDash, _cooldownDash;
    public PlayerInputs _inputs;

    public float cooldownDash
    {
        get => _cooldownDash;
        set
        {
            _cooldownDash = value;
            UIManager.instance.UpdateProgress(value);
        }
    }
    public bool onASlide
    {
        get => _onASlide;
        set
        {
            _onASlide = value;
            if (!onASlide)
            {
                _timerDash = 1;
            }
        }
    }

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
            _direction = new Vector2(_data.speedMovement, _rb.velocity.y);
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
            _direction.y /= 1.25f;
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
                dropEgg.Invoke();
                doubleJumped = true;
            }
        }
    }

    IEnumerator CoroutineDash()
    {
        animator.SetBool("Dash", true);
        _timerDash = _data.durationDash;
        _isDashing = true;
        dashInCooldown = true;
        
        do
        {
            _direction.x += _data.dashForce;
            if (!_onASlide)
            {
                _timerDash -= 0.1f;
            }

            yield return new WaitForEndOfFrame();
        } while (_timerDash > 0);
        
        animator.SetBool("Dash", false);
        _isDashing = false;
        StartCoroutine(CoroutineCooldownDash());
    }

    IEnumerator CoroutineCooldownDash()
    {
        cooldownDash = 0;
        do
        {
            cooldownDash += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        } while (cooldownDash < _data.cooldownDash);
        
        dashInCooldown = false;
    }


    public void Reset()
    {
        _rb.velocity = Vector2.zero;
        _isGrounded = true;
        doubleJumped = true;
        dashInCooldown = false;
        _isDashing = false;
        _onASlide = false;
    }

    public void StartGame()
    {
        animator.SetTrigger("Start");
    }
}