using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    private List<LimbPart> parts = new List<LimbPart>();
    public Transform root;
    public Vector2 resetPosition;
    public float force = 100;
    [Range(0f, 1f)]
    public float ratio = .9f;
    public bool fliped = false;
    public bool sin = false;

    [Space]
    public bool resting = false;


    void Start()
    {
        var hinge = GetComponent<HingeJoint2D>();
        while(hinge != null && hinge.transform != root) {
            parts.Add(new LimbPart(hinge.attachedRigidbody, fliped, sin));
            hinge = hinge.connectedBody.GetComponent<HingeJoint2D>();
        }
        parts.Reverse();
    }

    [Range(1f, 5f)]
    public float addedForce = 1f;
    public void SetPosition(Vector2 targetPos, float addedForce = 1f) {
        currentPos = targetPos + (Vector2)root.position;
        this.addedForce = addedForce;
        resetPos = false;
    }
    [SerializeField]
    bool resetPos = true;
    Vector2 currentPos;
    void FixedUpdate()
    {
        var force = this.force;
        if (resetPos) {
            currentPos = resetPosition + (Vector2)root.position;
            if (resting) {
                force *= 0.1f;
            }
        } else {
            resetPos = true;
        }
        var index = parts.Count;
        foreach(var part in parts) {
            part.RotateToward(currentPos, force * (index * (index + 1) * .5f * addedForce), ratio);
            index--;
        }
        addedForce = 1f;
    }

    private void OnDrawGizmos() {
        foreach(var p in parts) {
            p.OnDrawGizmos();
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(resetPosition + (Vector2)root.position, .1f);
    }
}
