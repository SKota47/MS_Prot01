using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletShotScript : MonoBehaviour
{
    [SerializeField]
    public GameObject _firingPoint;
    [SerializeField]
    public GameObject _bullet;
    [SerializeField]
    private float _speed = 24.0f;
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
        if (Input.GetKeyDown(KeyCode.Q) && _bulletCount > 0)
        {
            Shot();
            _bulletCount--;
        }
        _bulletCountText.text = _bulletCount.ToString() + "/5";
    }

    private void Shot()
    {
        Vector3 bulletPosition = _firingPoint.transform.position;
        GameObject newBall = Instantiate(_bullet, bulletPosition, transform.rotation);
        Vector3 direction = -newBall.transform.forward;
        newBall.GetComponent<Rigidbody>().AddForce(direction * _speed, ForceMode.Impulse);
        newBall.name = _bullet.name;

        Destroy(newBall, 0.8f);
    }
}
