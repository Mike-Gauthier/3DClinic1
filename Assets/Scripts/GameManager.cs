using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerHealth player;              //reference to playerMovement script
    LevelGenerator generator;
    GameObject playerObj;
    int score = 0;
    bool playerAlive = true;
    Coroutine scoreVar;
    Text scoreText;
    
    
    void Start(){
        GameObject temp;
        temp = GameObject.Find("Player");
        player = temp.GetComponent<PlayerHealth>();
        temp = GameObject.Find("LevelGen");
        generator = temp.GetComponent<LevelGenerator>();
        temp = GameObject.Find("ScoreText");
        scoreText = temp.GetComponent<Text>();
        scoreVar = StartCoroutine(scoring());
    }

    //when player reaches 0 health
    public void gameOver(){
        //freeze all enemies
        player.enabled = false;
        generator.enabled = false;
        StopAllCoroutines();                    //stops scoring coroutine
    }

    IEnumerator scoring(){
        while(playerAlive){
            score += 10;
            scoreText.text = "Score: " + score;
            yield return new WaitForSeconds(1f);
        }
    }
}
