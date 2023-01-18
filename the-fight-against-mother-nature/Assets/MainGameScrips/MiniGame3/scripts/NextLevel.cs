using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
 void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Endscene");
            Debug.Log("Next scene");
        }
    }

}
