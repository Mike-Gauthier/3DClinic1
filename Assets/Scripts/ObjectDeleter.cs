using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    GameManager gm;
    
    void Start() {
        GameObject temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider col) {
        if(col.tag == "Enemy"){
            gm.enemies -= 1;
            Destroy(col.gameObject);
        }else if(col.tag == "Obstacle"){
            gm.obstacles -= 1;
            Destroy(col.gameObject);
        }else if(col.tag == "Plane"){
            Destroy(col.gameObject);
        }
    }
}
