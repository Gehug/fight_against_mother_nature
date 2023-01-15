using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlat : MonoBehaviour

{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Platform")
        {
            transform.position = other.transform.position;
        }
    }
}


