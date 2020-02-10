using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    GameManager gm;

    float landSpeed = 1f;                        //speed terrain moves towards the player
    public GameObject plane;
    public GameObject[] obstacles = new GameObject[3];
    
    void Start(){
        GameObject temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
        spawnPlane();
        StartCoroutine(planeSpawner());
        StartCoroutine(enemySpawner());
        StartCoroutine(obstacleSpawner());  
    }
    
    //picks random plane prefab out of a list and spawns it
    void spawnPlane(){
        Instantiate(plane, new Vector3(0f,0f,60f), gameObject.transform.rotation);
    }

    //used to spawn enemies
    void spawnEnemy(){
        if(gm.enemies < 10){
            //random number for enemy type? yes obstacles and enemies
            //random number for position
            int tempLaneNum = Random.Range(1,4);            //picks lane to spawn in
            //spawn enemy
            switch(tempLaneNum){
                case 1:
                    Instantiate(obstacles[0], new Vector3(gm.lane1Coord,1f,50f), gameObject.transform.rotation);
                    break;
                case 2:
                    Instantiate(obstacles[0], new Vector3(0f,1f,50f), gameObject.transform.rotation);
                    break;
                case 3:
                    Instantiate(obstacles[0], new Vector3(gm.lane3Coord,1f,50f), gameObject.transform.rotation);
                    break;
                default:
                    break;
            }
            gm.enemies += 1;
        }
    }

    void spawnObstacle(){
        if(gm.obstacles < 10){
            //random number for obstacle type
            //random number for position
            int tempLaneNum = Random.Range(1,4);            //picks lane to spawn in
            int tempObjNum = Random.Range(2,3);             //pick obstacle to spawn
            switch(tempLaneNum){
                case 1:
                    Instantiate(obstacles[tempObjNum], new Vector3(gm.lane1Coord,.5f,50f), gameObject.transform.rotation);
                    break;
                case 2:
                    Instantiate(obstacles[tempObjNum], new Vector3(0f,.5f,50f), gameObject.transform.rotation);
                    break;
                case 3:
                    Instantiate(obstacles[tempObjNum], new Vector3(gm.lane3Coord,.5f,50f), gameObject.transform.rotation);
                    break;
                default:
                    break;
            }
            //spawn obstacle
            gm.obstacles += 1;
        }
    }

    //spawns planes on a timer
    IEnumerator planeSpawner(){
        while(true){
            yield return new WaitForSeconds(5f);
            spawnPlane();
        }
    }

    //actively spawns enemies
    IEnumerator enemySpawner(){
        while(true){
            float timeNum = Random.Range(3f, 6f);      //spawn time until next enemy
            yield return new WaitForSeconds(timeNum);
            spawnEnemy();
        }
    }

    //actively spawns obstacles
    IEnumerator obstacleSpawner(){
        while(true){
            float timeNum = Random.Range(2f, 4f);      //spawn time until next enemy
            yield return new WaitForSeconds(timeNum);
            spawnObstacle();
        }
    }
}
