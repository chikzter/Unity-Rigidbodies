using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapon : MonoBehaviour
{
    public Hand _handScript;
    private SpriteRenderer _myRend;
    private Collider2D _myCol;
    private Weapon _weapon;

    
    private void Start()
    {
        _myCol = GetComponent<Collider2D>();
        _myRend = GetComponent<SpriteRenderer>();
    }

    // Give interacting player a random gun packed with ammo
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _handScript = other.gameObject.GetComponentInChildren<Hand>();
            int ranNum = Random.Range(0, 5);
            _handScript._wep.SetActive(false);
            _handScript._wep = _handScript._weapons[ranNum];
            if (ranNum == 0)
            {
                _weapon = _handScript._wep.GetComponent<Weapon>();
                _weapon._ammunition = 30;
            }
            if (ranNum == 1)
            {
                _weapon = _handScript._wep.GetComponent<Weapon>();
                _weapon._ammunition = 6;
            }
            if (ranNum == 2)
            {
                _weapon = _handScript._wep.GetComponent<Weapon>();
                _weapon._ammunition = 2;
            }
            if (ranNum == 3)
            {
                _weapon = _handScript._wep.GetComponent<Weapon>();
                _weapon._ammunition = 6;
            }
            if (ranNum == 4)
            {
                _weapon = _handScript._wep.GetComponent<Weapon>();
                _weapon._ammunition = 12;
            }

            _myRend.enabled = false;
            _myCol.enabled = false;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(20);
        _myRend.enabled = true;
        _myCol.enabled = true;
    }
}
