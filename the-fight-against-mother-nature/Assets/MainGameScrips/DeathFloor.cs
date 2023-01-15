using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour
{

    public Transform player;
    [SerializeField] string RespawnName;
    

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            //RespawnAtCheckpoint();
            SceneManager.LoadScene(RespawnName);
        }
    }
}
