using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public int _attackDamage = 10;   //�U���_���[�W
    GameObject _attackObj;       //�U���͈͂̃R���C�_�[
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
            //�_���[�W��^����
            Destroy(collision.gameObject);
        }
    }
}
