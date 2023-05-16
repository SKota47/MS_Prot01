using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufSystemScript : MonoBehaviour
{
    public GameObject _bufPanel;
    public GameObject _player;
    public GameObject _attackBox;
    public GameObject _bullet;
    private PlayerMoveScripts _plScript;
    private PlayerAttackScript _plAttackScript;
    private BulletScript _bulletScript;
    // Start is called before the first frame update
    void Start()
    {
        _plScript = _player.GetComponent<PlayerMoveScripts>();
        _plAttackScript = _attackBox.GetComponent<PlayerAttackScript>();
        _bulletScript = _bullet.GetComponent<BulletScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_bufPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _plAttackScript._ATTACK_DAMAGE_MAX *= 3;
                _plScript._damageBySystem = (int)_plScript._currentHP / 2;
                _bufPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _bulletScript._bulletDamage += 10;
                _plScript._currentHP -= 10;
                _bufPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _bufPanel.SetActive(false);
            }
        }

    }
}
