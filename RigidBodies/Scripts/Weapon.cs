using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float _ammunition, _damage, _fireRate, _bSpeed, _accuracy, _shots;
    public string _gunName;
    public GameObject _bullet;
    private GameObject _rLowArm;
    private Transform _bulletTrans;


    private void Start()
    {
        _rLowArm = GameObject.Find("RLowerArm");
        _bulletTrans = GetComponentInChildren<Transform>();
    }
    public void NoAmmo()
    {
        Destroy(this.gameObject);
    }

    // Instantiate bullet with recoil and number of shots
    public void Shoot()
    {
        for (int i = 1; i <= _shots; i++)
        {
            var accuracy = Random.Range(-_accuracy, _accuracy);
            GameObject _instBullet = Instantiate(_bullet, _bulletTrans.position, _rLowArm.transform.rotation) as GameObject;
            _instBullet.transform.localScale = new Vector3(-transform.localScale.y, 2f, 1f);
            _instBullet.GetComponent<Rigidbody2D>().AddForce((transform.right * _bSpeed) + transform.up * accuracy);
            _instBullet.GetComponent<Bullet>()._dmg = _damage;
        }
    }
}