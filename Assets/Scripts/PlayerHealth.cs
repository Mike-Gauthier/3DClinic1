using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameManager gm;                         //reference to GameManager script
    
    bool canMove = true;
    int laneNum = 2;
    int health = 1;

    void Start() {
        GameObject temp;
        temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
    }

    void Update(){
        playerInput();
        //player movement between lanes
        switch(laneNum){
            case 1:
                Debug.Log("Lane 1");
                if(canMove){
                    gameObject.transform.position = new Vector3(-2f,0f,0f);
                    StartCoroutine(moveCooldown());
                }
                break;

            case 2:
                Debug.Log("Lane 2");
                if(canMove){
                    gameObject.transform.position = new Vector3(0f,0f,0f);
                    StartCoroutine(moveCooldown());
                }
                break;

            case 3:
                Debug.Log("Lane 3");
                if(canMove){
                    gameObject.transform.position = new Vector3(2f,0f,0f);
                    StartCoroutine(moveCooldown());
                }
                break;
            
            default:
                Debug.Log("Out of range, not moving lanes.");
                break;
        }
    }

    void OnTriggerEnter(Collider col) {
        //Check for enemy or obstacle damage
        if(col.tag == "Enemy" || col.tag == "Obstacle"){
            health = 0;
            gm.gameOver();
        }
    }

    //takes player input to change lanes
    void playerInput(){
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            if(laneNum != 1){
                laneNum -= 1;
            }
        }else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            if(laneNum != 3){
                laneNum += 1;
            }
        }
    }

    //resets canMove bool to true
    IEnumerator moveCooldown(){
        canMove = false;
        yield return new WaitForSeconds(.25f);
        canMove = true;
    }
}
