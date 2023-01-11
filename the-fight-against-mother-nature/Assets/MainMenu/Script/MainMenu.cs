using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame (){
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Load new scene");
    }

    public void QuitGame (){
        Debug.Log ("QUIT");
        Application.Quit();
    }


}