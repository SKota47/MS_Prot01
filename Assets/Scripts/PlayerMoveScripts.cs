using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveScripts : MonoBehaviour
{
    Rigidbody _rb;
    private float _speed = 20.0f;   //���ړ��̑��x
    private Vector2 _jumpPow = new Vector2(0.0f, 250.0f);   //�W�����v�̃p���[
    private bool _isJump = false;   //�W�����v���Ă��邩

    public int _maxHP = 100;        //�ő�̗�
    public float _currentHP;        //���݂̗̑�
    private float _damage = 0;      //�󂯂�_���[�W
    [System.NonSerialized]
    public int _damageFromReload = 0;
    [System.NonSerialized]
    public int _damageByTouch = 0;
    [System.NonSerialized]
    public int _damageBySystem = 0;

    public Slider _hpBar;            //HP�Q�[�W�̃X���C�_�[
    public GameObject _hpValue;      //UI
    private Text _hpText;            //UI

    public GameObject _attackBox;       //�U�����̓����蔻��Cube
    private Collider _attackCollision;  //�����蔻��R���C�_�[(�����炭���g�p)

    public GameObject _bullel;
    private BulletShotScript _bsShot;

    public float _attackTime = 0;
    private const float _ATTACK_TIME_MAX = 0.25f;
    private bool _isAttack = false;
    private const float _ATTACK_DEFUSE_MAX = 2;
    private float AttackDefuse = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentHP = _maxHP;
        _hpText = _hpValue.GetComponent<Text>();
        _bsShot = _bullel.GetComponent<BulletShotScript>();
    }

    void Update()
    {
        //�ړ�
        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            _rb.AddForce(Vector3.up * _jumpPow, ForceMode.Impulse);
            _isJump = true;
        }
        //���ړ�
        _rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y, 0);
        //���ړ����̔��]
        if (_rb.velocity.x > 0) transform.eulerAngles = new Vector3(0, -90, 0);
        if (_rb.velocity.x < 0) transform.eulerAngles = new Vector3(0, 90, 0);

        //�v���C���[�Ƀ_���[�W
        //if (Input.GetKeyDown(KeyCode.P)) _damage = 1;

        //�U���ƍU������I���I�t
        if (Input.GetKeyDown(KeyCode.E) && !_isAttack)
        {
            _attackBox.gameObject.SetActive(true);
            _isAttack = !_isAttack;
        }
        else if (_attackTime >= _ATTACK_TIME_MAX)
        {
            _attackBox.gameObject.SetActive(false);
            _isAttack = !_isAttack;
            _attackTime = 0;
        }
        if (_isAttack)
        {
            _attackTime += Time.deltaTime;
        }

        //HP�̏���

        if (Input.GetKeyDown(KeyCode.R))
        {
            _damageFromReload = (5 - _bsShot._bulletCount) * 2;
            _bsShot._bulletCount = 5;
        }

        HPCulc();
    }

    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Floor") && _isJump) _isJump = false;  //�W�����v
    }

    private void HPCulc()
    {
        _currentHP -= _damage;
        _currentHP -= _damageFromReload;
        _currentHP -= _damageByTouch;
        _currentHP -= _damageBySystem;
        _hpBar.value = _currentHP / _maxHP;
        _hpText.text = _currentHP.ToString();
        _damage = 0;
        _damageFromReload = 0;
        _damageByTouch = 0;
        _damageBySystem = 0;
    }
}