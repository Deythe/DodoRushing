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
    private float timerDash;
    public PlayerInputs _inputs;

    public bool onASlide
    {
        get => _onASlide;
        set
        {
            _onASlide = value;
            if (!onASlide)
            {
                timerDash = _data.durationDash * 0.5f;
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
        SoundManager.instance.PlaySoundOnce("Jump");
        if (_isGrounded)
        {
            _direction = new Vector2(_direction.x, _data.jumpForce);
        }
        else
        {
            if (!doubleJumped)
            {
                _direction = new Vector2(_direction.x, _data.jumpForce);
                SoundManager.instance.PlaySoundOnce("PopEgg");
                dropEgg.Invoke();
                doubleJumped = true;
            }
        }
    }

    IEnumerator CoroutineDash()
    {
        SoundManager.instance.PlaySound("Slide");
        timerDash = _data.durationDash;
        _isDashing = true;
        dashInCooldown = true;
        _direction.x += _data.dashForce;
        do
        {
            if (!_onASlide)
                timerDash -= Time.deltaTime;
            yield return new WaitForEndOfFrame();

        } while (timerDash > 0);
        
        _isDashing = false;
        _direction.x -= _data.dashForce;
        SoundManager.instance.PlaySound("Slide",false);
        StartCoroutine(CoroutineCooldownDash());
    }

    IEnumerator CoroutineCooldownDash()
    {
        yield return new WaitForSeconds(_data.cooldownDash);
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