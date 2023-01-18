using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject txtToDisplay;             //display the UI text
    private MainGameController controller;



    // Start is called before the first frame update
    void Start()
    {

        txtToDisplay.SetActive(true);
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGameController> ();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))           //if press F key
        {
            Destroy(this.gameObject);
            txtToDisplay.SetActive(false);
            controller.EnableTimer();
        }
    }


}