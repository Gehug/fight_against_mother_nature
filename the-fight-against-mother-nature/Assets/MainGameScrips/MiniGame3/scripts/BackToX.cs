using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToX : MonoBehaviour
{
 void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("MiniGame1");
            Debug.Log("Back to x");
        }
    }
}
