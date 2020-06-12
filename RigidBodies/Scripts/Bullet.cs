using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Collider2D _body, _stairs;
    private Rigidbody2D _rBody;
    public GameObject _rotObj;
    public float _destroyTime, _dmg;
    public PlayerController _player;
    private AudioSource _audio;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _rBody = GetComponent<Rigidbody2D>();
        _audio.pitch = Random.Range(1, 4);
        _audio.Play();
        Destroy(this.gameObject, _destroyTime);
    }

    // Flip bullet acording to where it's shot from
    private void Update()
    {
        _rotObj.transform.rotation = Quaternion.LookRotation(_rBody.velocity);

        if (transform.localScale.x == 2)
        {
            Quaternion rot = Quaternion.Euler(0, 0, _rotObj.transform.eulerAngles.x);
            transform.localRotation = rot;
        }

        if (transform.localScale.x == -2)
        {
            Quaternion rot = Quaternion.Euler(0, 0, _rotObj.transform.eulerAngles.x * -1);
            transform.localRotation = rot;
        }
    }
}