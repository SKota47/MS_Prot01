using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletShotScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 30f;

    [SerializeField]
    public int _bulletCount = 5;

    public GameObject _bulletCountUI;
    private Text _bulletCountText;

    private void Start()
    {
        _bulletCountText = _bulletCountUI.GetComponent<Text>();
    }

    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ���𔻒�
        if (Input.GetKeyDown(KeyCode.Q) && _bulletCount > 0)
        {
            // �e�𔭎˂���
            Shot();
            _bulletCount--;
        }
        _bulletCountText.text = _bulletCount.ToString();
    }

    /// <summary>
	/// �e�̔���
	/// </summary>
    private void Shot()
    {
        Vector3 bulletPosition = firingPoint.transform.position;
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        Vector3 direction = -newBall.transform.forward;
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        newBall.name = bullet.name;

        Destroy(newBall, 0.8f);
    }
}
