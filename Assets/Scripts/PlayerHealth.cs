using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameManager gm;                         //reference to GameManager script
    int health = 1;

    void OnTriggerEnter(Collider col) {
        //Check for enemy or obstacle damage
        if(col.tag == "Enemy" || col.tag == "Obstacle"){
            health = 0;
            gm.gameOver();
        }
    }
}
