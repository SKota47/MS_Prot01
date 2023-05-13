using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveScripts : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _input;
    private float _speed = 20.0f;
    public Slider _hpSlider;
    public int _maxHP = 100;
    public float _currentHP;
    private float _damage = 0;

    public GameObject _hpObject;
    private Text _hpText;

    private Vector2 _jumpPow = new Vector2(0.0f, 250.0f);
    private bool _isJump = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentHP = _maxHP;
        _hpText = _hpObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            _rb.AddForce(Vector3.up * _jumpPow, ForceMode.Impulse);
            _isJump = true;
        }
        _rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            _damage = 1;
        }
        else _damage = 0;
        _currentHP -= _damage;
        _hpSlider.value = _currentHP / _maxHP;
        _hpText.text = _currentHP.ToString();
    }

    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor")) _isJump = false;
    }
}