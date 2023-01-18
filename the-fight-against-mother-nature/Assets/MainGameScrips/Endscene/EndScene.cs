using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void PlayGame (){
        SceneManager.LoadScene("Main_Menu");
        Debug.Log("restart game");
    }

    public void QuitGame (){
        Debug.Log ("QUIT");
        Application.Quit();
    }
}
