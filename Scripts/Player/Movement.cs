using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerJumped;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce;

    private readonly string _run2 = "_Run2";
    private readonly string _run1 = "_Run1";
    private readonly string _stop = "_Stop";
    private readonly string _jump = "_Jump";
    private readonly string _down = "_Down";
    private bool _stopMove = false;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_stopMove == false)
        {
            _animator.SetBool(_stop, false);

            if (Input.GetKey(KeyCode.D))
            {
                _animator.SetBool(_run2, false);
                _animator.SetBool(_jump, false);
                _animator.SetBool(_down, false);
                _animator.SetBool(_run1, true);
                transform.Translate(_speed * Time.deltaTime, 0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _animator.SetBool(_run1, false);
                _animator.SetBool(_jump, false);
                _animator.SetBool(_down, false);
                _animator.SetBool(_run2, true);
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _animator.SetBool(_run2, false);
                _animator.SetBool(_run1, false);
                _animator.SetBool(_down, false);
                _animator.SetBool(_jump, true);
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
                _playerJumped?.Invoke();
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