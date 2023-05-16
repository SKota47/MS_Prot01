using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletShotScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("íeÇÃî≠éÀèÍèä")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("íe")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("íeÇÃë¨Ç≥")]
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
        // ÉXÉyÅ[ÉXÉLÅ[Ç™âüÇ≥ÇÍÇΩÇ©ÇîªíË
        if (Input.GetKeyDown(KeyCode.Q) && _bulletCount > 0)
        {
            // íeÇî≠éÀÇ∑ÇÈ
            Shot();
            _bulletCount--;
        }
        _bulletCountText.text = _bulletCount.ToString();
    }

    /// <summary>
	/// íeÇÃî≠éÀ
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
