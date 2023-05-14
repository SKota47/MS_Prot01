using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public int _attackDamage = 10;   //攻撃ダメージ
    GameObject _attackObj;       //攻撃範囲のコライダー
    Collider _collider;

    private void Start()
    {
        //_collider = _attackObj.GetComponent<Collider>();
    }

    public void Attack()
    {
       // _collider.enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //ダメージを与える
            Destroy(collision.gameObject);
        }
    }
}
