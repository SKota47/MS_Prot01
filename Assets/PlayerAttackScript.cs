using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    private int _ATTACK_DAMAGE_MAX = 10;   //攻撃ダメージ
    public int _attackDamage;
    public GameObject _attackObj;       //攻撃範囲のコライダー
    Collider _collider;

    bool _isAttack = false;

    GameObject _player;
    PlayerMoveScripts _plMoveScripts;

    private void Start()
    {
        _attackDamage = 0;
        _player = GameObject.Find("Player");
        _plMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _attackObj.SetActive(false);
        //_collider = _attackObj.GetComponent<Collider>();
    }

    private void Update()
    {
        if (_isAttack)
        {
            _attackDamage = 0;
        }
        if (!_attackObj.activeSelf)
        {
            _isAttack = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") && !_isAttack)
        {
            _attackDamage = _ATTACK_DAMAGE_MAX;
            _isAttack = true;
        }
        else
        {
            _attackDamage = 0;
        }
    }
}
