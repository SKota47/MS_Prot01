using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveScripts : MonoBehaviour
{
    Rigidbody _rb;
    private float _speed = 20.0f;   //横移動の速度
    private Vector2 _jumpPow = new Vector2(0.0f, 250.0f);   //ジャンプのパワー
    private bool _isJump = false;   //ジャンプしているか

    public int _maxHP = 100;        //最大体力
    public float _currentHP;        //現在の体力
    private float _damage = 0;      //受けるダメージ
    [System.NonSerialized]
    public int _damageFromReload = 0;
    [System.NonSerialized]
    public int _damageByTouch = 0;
    [System.NonSerialized]
    public int _damageBySystem = 0;

    public Slider _hpBar;            //HPゲージのスライダー
    public GameObject _hpValue;      //UI
    private Text _hpText;            //UI

    public GameObject _attackBox;       //攻撃時の当たり判定Cube
    private Collider _attackCollision;  //当たり判定コライダー(おそらく未使用)

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
        //移動
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            _rb.AddForce(Vector3.up * _jumpPow, ForceMode.Impulse);
            _isJump = true;
        }
        //横移動
        _rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y, 0);
        //横移動時の反転
        if (_rb.velocity.x > 0) transform.eulerAngles = new Vector3(0, -90, 0);
        if (_rb.velocity.x < 0) transform.eulerAngles = new Vector3(0, 90, 0);

        //プレイヤーにダメージ
        //if (Input.GetKeyDown(KeyCode.P)) _damage = 1;

        //攻撃と攻撃判定オンオフ
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

        //HPの処理

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
         if (other.gameObject.CompareTag("Floor") && _isJump) _isJump = false;  //ジャンプ
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