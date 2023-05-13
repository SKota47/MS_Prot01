using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScripts : MonoBehaviour
{
    Rigidbody _rb;
    CharacterController _charCon;
    Vector2 _move;
    public float _speed = 4.0f;

    private bool _isGrounded;
    private float _jumpPow = 40.0f;
    private bool _isJump = false;
    private float _gravity = 9.8f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _charCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _charCon.isGrounded;
        Debug.Log(_charCon.isGrounded);
        _move.x = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        //_move.y = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            _move.y = Time.deltaTime * _jumpPow;
            _isJump = true;
        }
        else if (_isJump && _isGrounded)
        {
            _move.y = 0;
            _isJump = false;
        }
        _move.y -= _gravity;
        _charCon.Move(_move);
    }
}