using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        GameObject temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
        //StartCoroutine(switchLanes());
    }
    
    void FixedUpdate(){
        //move enemy towards player
        rb.velocity = -transform.forward * gm.enemySpeed;
    }

    // //WORK IN PROGRESS
    // //allows enemy to switch lanes
    // IEnumerator switchLanes(){
    //     while(true){
    //         yield return new WaitForSeconds(Random.Range(5f,10f));
    //         int randLane = Random.Range(1,4);
    //         switch(randLane){
    //             case 1: 
    //                 gameObject.transform.position = new Vector3(-2f, gameObject.transform.position.y, gameObject.transform.position.z);
    //                 break;
    //             case 2: 
    //                 gameObject.transform.position = new Vector3(0f, gameObject.transform.position.y, gameObject.transform.position.z);
    //                 break;
    //             case 3: 
    //                 gameObject.transform.position = new Vector3(2f, gameObject.transform.position.y, gameObject.transform.position.z);
    //                 break;
    //             default: 
    //                 Debug.Log("Enemy failed to switch lanes. EnemyMovement Script");
    //                 break;
    //         }
    //     }
    // }
}
