using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{

    //[SerializeField] GameObject startGameCanvas;
    //[SerializeField] bool enableStartGameCanvasOnStartUp;

   
    [SerializeField] GameObject playAgainCanvas;

    [SerializeField] GameObject pauseCanvas;

    [SerializeField] string levelToLoad;



    [SerializeField] bool startTimer = true;

    [SerializeField] float timeLeft = 180f;
    [SerializeField] Text timerText; // used for showing countdown from 3, 2, 1







    // Update is called once per frame
    void Update()
    {

        if (startTimer)
        {

            UpdateTimer();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();


            }

        }


    }


    public void EnableTimer()
    {
        startTimer = true;
    }

    public void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)


        {

            if (levelToLoad != null)
            {

                LoadLevel();
                startTimer = false;
                timerText.text = "0";
            }
        }
    }



    public void TogglePause()
    {
        if (Time.timeScale > 0) { // Game staat niet in pauze
            Time.timeScale = 0; // zet game op pauze 
            pauseCanvas.SetActive(true);
            AudioListener.pause = true;
            Cursor.visible = true;



        }
        else if (Time.timeScale == 0)
        {

            Time.timeScale = 1; // zet game niet meer op pauze 
            pauseCanvas.SetActive(false);
            AudioListener.pause = false;
            Cursor.visible = false;

        }
    }





    public void EnablePlayAgainCanvas()
    {

        playAgainCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void DisablePlayAgainCanvas()
    {

        playAgainCanvas.SetActive(false);
        //Cursor.visible = false;

    }


    public void LoadLevel()
    {
        //Load the new level (mLevelToLoad)
        SceneManager.LoadScene(levelToLoad);
    }




}

