using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEarthQuake : MonoBehaviour
{


    private List<GameObject> Blocks;
    private float timePassed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Block")
            {

                print(child.gameObject.name);
                Blocks.Add(child.gameObject);
               
            }
        }

        InvokeRepeating(nameof(DestroyRandomChild), 2.0f, 3.0f); // start na 2seconden, en zal om 3 seconden de functie uitvoeren
    }



    private void DestroyRandomChild()
    {
        //timePassed += Time.deltaTime;
        //if (timePassed > 3f) // destroys om de 3 secoden een random block
        //{

        int randomBlock = Random.Range(0, Blocks.Count);

    }


}
