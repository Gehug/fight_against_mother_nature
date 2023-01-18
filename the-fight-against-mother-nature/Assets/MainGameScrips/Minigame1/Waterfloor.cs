using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waterfloor : MonoBehaviour
{
    public Transform player;

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            //RespawnAtCheckpoint();
            SceneManager.LoadScene("MiniGame1");
        }
    }
}