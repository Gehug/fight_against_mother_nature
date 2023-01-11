using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject txtToDisplayOven;             //display the UI text

    private bool PlayerInZone;

    private void Start()
    {
        PlayerInZone = false;                   //player not in zone     
        txtToDisplayOven.SetActive(true);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.F))           //if in zone and press F key
        {
            txtToDisplayOven.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            PlayerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
        }
    }
}