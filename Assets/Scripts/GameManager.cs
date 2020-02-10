using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Scripts
    LevelGenerator generator;           
    PlayerHealth player;

    
    //Various
    bool playerAlive = true;
    public float enemySpeed;
    public float planeSpeed;
    GameObject playerObj;

    //LevelGen
    public float lane1Coord = -2.4f;                        //coordinates of lane 1
    public float lane3Coord = 2.4f;
    public int enemies = 0;
    public int obstacles = 0;
    
    //UI
    public GameObject gameOverMenu;
    public Text endScoreText;                               //scoretext on game over screen
    GameObject objText;                                     //objective text shown at beginning of game
    Coroutine scoreVar;                   
    Text scoreText;                                         //score counter at bottom left
    int score = 0;                                          //variable for score
    
    void Start(){
        //sets default speed for planes and enemies
        planeSpeed = 2.25f;
        enemySpeed = 2.5f;

        //various variable assignment
        GameObject temp = GameObject.Find("Player");
        player = temp.GetComponent<PlayerHealth>();
        temp = GameObject.Find("LevelGen");
        generator = temp.GetComponent<LevelGenerator>();
        temp = GameObject.Find("ScoreText");
        objText = GameObject.Find("ObjectiveText");
        scoreText = temp.GetComponent<Text>();
        
        //start coroutines
        scoreVar = StartCoroutine(scoring());               //start counting score
        StartCoroutine(startUp());
    }

    //when player reaches 0 health (collides with enemy or obstacle)
    public void gameOver(){
        scoreText.enabled = false;
        endScoreText.text = "Final Score: " + score;
        gameOverMenu.SetActive(true);                       //enables game over menu UI
        enemySpeed = 0f;                                    //freeze all enemies
        planeSpeed = 0f;
        player.enabled = false;
        generator.enabled = false;                          //disables level generator
        StopAllCoroutines();                                //stops scoring coroutine
    }

    //hides objective text after 3 seconds
    IEnumerator startUp(){
        yield return new WaitForSeconds(3f);
        objText.SetActive(false);
    }
    
    //gives player score
    IEnumerator scoring(){
        yield return new WaitForSeconds(3f);
        while(playerAlive){
            score += 10;
            scoreText.text = "Score: " + score;
            yield return new WaitForSeconds(1f);
        }
    }
}
