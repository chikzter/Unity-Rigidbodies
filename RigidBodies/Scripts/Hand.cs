using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public GameObject _wep;
    public GameObject[] _weapons;
    private bool _equipped, _loader, _mlee = false;
    private float _dmg, _ammo, _fRate, _points;
    private string _gun;
    public Weapon _myScript;
    private Text _txt;
    public Text[] _txtList;
    public float timeLeft;
    public Animator _anim;
    public PlayerManager_Script _managerScript;


    private void Start()
    {
        _txtList = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        _managerScript = GetComponentInParent<PlayerManager_Script>();
        _txt = _txtList[_managerScript._IDdata];
        timeLeft = 0;
        _wep = _weapons[0];
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        _anim.SetBool("SWING", false);
    }

    // Fire weapon
    private void OnShoot()
    {
        if (_loader == true)
        {
            if (timeLeft >= _fRate && _ammo >= 1)
            {
                _ammo--;
                _myScript.Shoot();

                timeLeft = 0;
                if (_mlee == true)
                {
                    _anim.SetBool("SWING", true);
                    StartCoroutine(Timer());
                }
                _myScript._ammunition = _ammo;
                _txt.text = " Player 1 " + "Score " + _points + "\n" + _gun + " : " + _ammo + " Charges";
            }
        }
    }

    // Check for weapon
    // Change weapons
    // Rotate weapons
    private void Update()
    {
        timeLeft += Time.deltaTime;

        if (_wep == _weapons[0])
        {
            _wep.SetActive(false);
            _mlee = false;
            _equipped = !_equipped;
        }
        if (_wep == _weapons[1])
        {
            _wep.SetActive(false);
            _mlee = false;
            _equipped = !_equipped;
        }
        if (_wep == _weapons[2])
        {
            _wep.SetActive(false);
            _mlee = false;
            _equipped = !_equipped;
        }
        if (_wep == _weapons[3])
        {
            _wep.SetActive(false);
            _mlee = true;
            _equipped = !_equipped;
        }
        if (_wep == _weapons[4])
        {
            _wep.SetActive(false);
            _mlee = false;
            _equipped = !_equipped;
        }


        if (_equipped == true)
        {
            _myScript = _wep.GetComponent<Weapon>();
            _dmg = _myScript._damage;
            _ammo = _myScript._ammunition;
            _gun = _myScript._gunName;
            _fRate = _myScript._fireRate;
            _wep.SetActive(true);

            _loader = true;
            _equipped = false;

            _myScript._ammunition = _ammo;
            _txt.text = " Player 1 " + "Score " + _points + "\n" + _gun + " : " + _ammo + " Charges";
        }

        if (_wep != null)
        {
            if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 90)
            {
                _wep.transform.localScale = new Vector3(2f, -2f, 1f);
            }

            if (transform.eulerAngles.z >= 270 && transform.eulerAngles.z < 360)
            {
                _wep.transform.localScale = new Vector3(2f, -2f, 1f);
            }

            if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z < 270)
            {
                _wep.transform.localScale = new Vector3(2f, 2f, 1f);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Top")
        {
            _points = _points + Time.deltaTime;
        }
    }
}