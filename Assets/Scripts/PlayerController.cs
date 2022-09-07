using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private float _groundCheckRadius = 0.2f;
    private float _horizontal;
    private bool _isFacingRight = true;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    private static readonly int SpeedKey = Animator.StringToHash("speed");
    private static readonly int JumpKey = Animator.StringToHash("isJumping");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        
        Flip();
        
        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
        
        _animator.SetFloat(SpeedKey, Mathf.Abs(_horizontal));
        _animator.SetBool(JumpKey, !IsGrounded());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_horizontal * _speed, _rigidbody.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            var localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
