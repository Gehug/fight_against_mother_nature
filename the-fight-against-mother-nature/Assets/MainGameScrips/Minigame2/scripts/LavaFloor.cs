using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaFloor : MonoBehaviour
{
    public Transform player;

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            //RespawnAtCheckpoint();
            SceneManager.LoadScene("MiniGame2");
        }
    }

    /*private void RespawnAtCheckpoint()
    {
        if (PlayerPrefs.HasKey("CheckpointX"))
        {
            Vector3 checkpointPos = new Vector3(PlayerPrefs.GetFloat("CheckpointX"), PlayerPrefs.GetFloat("CheckpointY"), PlayerPrefs.GetFloat("CheckpointZ"));
            player.position = checkpointPos;
            SceneManager.LoadScene("MiniGame2");
            
        }
        else
        {
            SceneManager.LoadScene("MiniGame2");
        }
    }*/
}
