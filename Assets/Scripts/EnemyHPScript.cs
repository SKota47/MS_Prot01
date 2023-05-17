using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �قƂ��HP�̊Ǘ������Ă��邾���ł�
/// ����C���^�[�t�F�[�X������\�肵�Ă��܂�
/// </summary>
public class EnemyHPScript : MonoBehaviour
{
    private float _maxHP;
    public Slider _slider;
    private float _currentHP;
    public float _damage;

    private string _enemyType;

    GameObject _player;
    PlayerAttackScript _plAttackScript;

    void Awake()
    {

    }

    private void Start()
    {
        _enemyType = gameObject.tag;
        switch (_enemyType)
        {
            case "Enemy01":
                _maxHP = 200;
                break;
            case "Enemy02":
                _maxHP = 20;
                break;
            case "Enemy03":
                _maxHP = 50;
                break;
            default:
                Debug.LogError("�G�l�~�[��HP���ݒ�ł��܂���ł���");
                break;
        }

        _currentHP = _maxHP;

        _player = GameObject.Find("AttackBox");
        _plAttackScript = _player.GetComponent<PlayerAttackScript>();
        _slider = GetComponentInChildren<Slider>();
    }

    public void Update()
    {
        _currentHP -= _damage;
        _slider.value = _currentHP / _maxHP;

        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
        _damage = 0;
    }
}
