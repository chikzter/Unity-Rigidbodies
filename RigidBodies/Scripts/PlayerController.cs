using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _torso;
    public Limb _rHand, _lHand, _rLeg, _lLeg;
    private Rigidbody2D _me;
    public float _torsoForce, _moveSpeed, _jumpForce, _health;
    public int _jumps, _jumpCharge;
    private float _jTimer = 0;

    public bool _isMe = true;
    private bool _isDead;
    public bool _airBorne = false;

    private Vector2 _aimDir, _movDir;
    private Bullet _bulletScript;

    private Transform[] _spawnPoints;
    private PlayerManager_Script _managerScript;


    private void Start()
    {
        _managerScript = GetComponentInParent<PlayerManager_Script>();
        _me = this.GetComponent<Rigidbody2D>();
        _spawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
        int ranNum = Random.Range(0, 6);
        transform.position = _spawnPoints[ranNum].position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("Shot");
            _bulletScript = other.gameObject.GetComponent<Bullet>();
            _health -= _bulletScript._dmg;
        }
    }

    // Jump timer
    public void Grounder(bool value)
    {
        if (value)
        {
            if (_jTimer > Time.timeSinceLevelLoad)
            {
                return;
            }
            _jumpCharge = _jumps;
        }
    }

    // Remove stable legs
    // Falls on death
    public void Kill()
    {
        _isDead = true;
        _lLeg.resting = true;
        _rLeg.resting = true;
        this.enabled = false;
        _rHand.GetComponent<Hand>().enabled = false;
        _managerScript.Respawn();
    }

    // Check for user input
    void Update()
    {
        Move();

        if (_health <= 0)
        {
            Kill();
        }

        if (_aimDir != Vector2.zero)
        {
            _rHand.SetPosition(_aimDir, 5);
            _lHand.SetPosition(_aimDir, 5);
        }

        if (_isDead)
        {
            return;
        }

        RotateTo(_torso, 0, _torsoForce);
        if (!_isMe)
            return;
    }

    void RotateTo(Rigidbody2D _body, float _angle, float _force)
    {
        _angle = Mathf.DeltaAngle(transform.eulerAngles.z, _angle);
        var x = _angle > 0 ? 1 : -1;
        _angle = Mathf.Abs(_angle * .1f);
        if (_angle > 2)
        {
            _angle = 2;
        }
        _angle *= .5f;
        _angle *= (1 + _angle);
        _body.angularVelocity *= .5f;
        _body.AddTorque(_angle * _force * x);
    }

    private void Move()
    {
        if (Mathf.Abs(_movDir.x) > 0)
        {
            _torso.AddForce(_moveSpeed * _movDir * 2 * Vector2.right);
        }
    }

    // Movement
    private void OnMove(InputValue value)
    {
        Debug.Log("Move");
        _movDir = value.Get<Vector2>();
    }

    // Get user input from right analog stick
    private void OnAim(InputValue value)
    {
        Debug.Log("Aim");
        _aimDir = value.Get<Vector2>();
    }

    // When jump key is pressed jump and remove jump charges
    private void OnJump()
    {
        if (_jumpCharge > 0 && _isDead == false)
        {
            Debug.Log("Jumped");
            _torso.velocity = Vector2.zero;
            _torso.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            _jumpCharge--;
            _jTimer = Time.timeSinceLevelLoad + .1f;
        }
    }
}
