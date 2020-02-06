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
    GameObject objText;
    public GameObject gameOverMenu;
    public Text endScoreText;
    
    void Start(){
        GameObject temp;
        temp = GameObject.Find("Player");
        player = temp.GetComponent<PlayerHealth>();
        temp = GameObject.Find("LevelGen");
        generator = temp.GetComponent<LevelGenerator>();
        temp = GameObject.Find("ScoreText");
        objText = GameObject.Find("ObjectiveText");
        scoreText = temp.GetComponent<Text>();
        scoreVar = StartCoroutine(scoring());
        StartCoroutine(startUp());
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            gameOver();
            Debug.Log("Pressed 'E', game over sequence running");
        }
    }

    //when player reaches 0 health
    public void gameOver(){
        scoreText.enabled = false;
        endScoreText.text = "Final Score: " + score;
        gameOverMenu.SetActive(true);
        //freeze all enemies
        player.enabled = false;
        generator.enabled = false;
        StopAllCoroutines();                    //stops scoring coroutine
    }

    //hides objective text after 3 seconds
    IEnumerator startUp(){
        yield return new WaitForSeconds(3f);
        objText.SetActive(false);
    }
    
    //gives player score
    IEnumerator scoring(){
        while(playerAlive){
            score += 10;
            scoreText.text = "Score: " + score;
            yield return new WaitForSeconds(1f);
        }
    }
}
