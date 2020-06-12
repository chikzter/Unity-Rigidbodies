using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollision : MonoBehaviour
{
    Collider2D[] _colliders;
    private List<GameObject> _platform = new List<GameObject>();


    void Start()
    {
        // Ignores collision between child colliders
        _colliders = GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < _colliders.Length; i++)
        {
            for (int k = i+1; k < _colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(_colliders[i], _colliders[k]);
            }
        }

        foreach(GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
        {
            _platform.Add(platform);
        }
    }

    public void ColliderDisabler()
    {
        foreach (GameObject platform in _platform)
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                Physics2D.IgnoreCollision(platform.GetComponent<Collider2D>(), _colliders[i]);
            }
        }
    }

    public void ColliderEnabler()
    {
        foreach (GameObject platform in _platform)
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                Physics2D.IgnoreCollision(platform.GetComponent<Collider2D>(), _colliders[i], false);
            }
        }
    }
}
