using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        GameObject temp;
        temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
        StartCoroutine(delete());
    }
    
    void FixedUpdate(){
        //move enemy towards player
        rb.velocity = -transform.forward * gm.enemySpeed;
    }

    IEnumerator delete(){
        yield return new WaitForSeconds(30f);
        Destroy(this.gameObject);
    }
}
