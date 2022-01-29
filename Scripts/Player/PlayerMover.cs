using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerJumped;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minWidth;
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _jumpPlayer;

    private string _run2 = "_Run2";
    private string _run1 = "_Run1";
    private string _stop = "_Stop";
    private string _jump = "_Jump";
    private string _down = "_Down";
    private Animator _animator;
    private Vector3 _targetPosition;
    private bool _stopMove = false;
    private float _stopJump = 0;

    private void Start()
    {
        _jumpPlayer = 15.0f;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _targetPosition = transform.position;

        if (_stopMove == false)
        {
            _animator.SetBool(_stop, false);
            
            if (Input.GetKey(KeyCode.D))
            {
                if (_targetPosition.x < _maxWidth)
                {
                    _animator.SetBool(_run2, false);
                    _animator.SetBool(_jump, false);
                    _animator.SetBool(_down, false);
                    _animator.SetBool(_run1, true);
                    transform.Translate(_speed * Time.deltaTime, 0, 0, 0);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (_targetPosition.x > _minWidth)
                {
                    _animator.SetBool(_run1, false);
                    _animator.SetBool(_jump, false);
                    _animator.SetBool(_down, false);
                    _animator.SetBool(_run2, true);
                    transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
                }
            }

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                if (_targetPosition.y < _maxHeight)
                {
                    _jumpForce = _jumpPlayer;
                    _animator.SetBool(_run2, false);
                    _animator.SetBool(_run1, false);
                    _animator.SetBool(_down, false);
                    _animator.SetBool(_jump, true);
                    _rigidbody2D.AddForce(Vector2.up * _jumpForce);
                    _playerJumped?.Invoke();
                }

                else if (_targetPosition.y > _maxHeight)
                {
                    _targetPosition.y = _maxHeight;
                    _jumpForce = _stopJump;
                }
            }


            if (Input.GetKey(KeyCode.S))
            {
                _animator.SetBool(_run2, false);
                _animator.SetBool(_run1, false);
                _animator.SetBool(_jump, false);
                _animator.SetBool(_down, true);
                _rigidbody2D.AddForce(Vector2.down * _jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _stopMove = true;
            _animator.SetBool(_run1, false);
            _animator.SetBool(_run2, false);
            _animator.SetBool(_jump, false);
            _animator.SetBool(_stop, true);
        }
        else
        {
            _stopMove = false;
        }
    }
}