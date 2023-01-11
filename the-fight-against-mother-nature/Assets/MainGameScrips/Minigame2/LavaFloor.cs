using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaFloor : MonoBehaviour
{

    public void OnTriggerEnter(Collider Col)
    {

        if (Col.gameObject.tag == "Player")
        {
            Debug.Log("RIP, try again");
            SceneManager.LoadScene("Lava_MiniGame");
        }

    }

}
