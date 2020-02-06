using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        GameObject temp;
        temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
    }
    
    void FixedUpdate(){
        //move enemy towards player
        rb.velocity = -transform.forward * gm.enemySpeed;
    }
}
