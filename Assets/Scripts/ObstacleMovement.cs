using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        GameObject temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
    }
    
    void FixedUpdate(){
        //move obstacle towards player
        rb.velocity = -transform.forward * gm.planeSpeed;
    }
}
