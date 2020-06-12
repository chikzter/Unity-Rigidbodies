using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    int grounded = 0;
    PlayerController controller;


    void Start()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    // Check for ground
    private void OnCollisionEnter2D(Collision2D collision) {
        if(grounded < 1) {
            controller.Grounder(true);
            controller._airBorne = false;
        }
        grounded++;
    }

    // Check for ground exit
    private void OnCollisionExit2D(Collision2D collision) {
        grounded--;
        if (grounded < 1) {
            controller.Grounder(false);
            controller._airBorne = true;
            grounded = 0;
        }
    }

}
