using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //quits application
    public void quitGame(){
        Debug.Log("Quitting the game via quitGame function.");
        Application.Quit();
    }

    //go to specified scene index number
    //0 = _MainMenu, 1 = GameLevel
    public void goToLevel(int index){
        if(index == 0){
            SceneManager.LoadScene(0);
        }else if(index != 0){
            SceneManager.LoadScene(1);
        }
    }
}
