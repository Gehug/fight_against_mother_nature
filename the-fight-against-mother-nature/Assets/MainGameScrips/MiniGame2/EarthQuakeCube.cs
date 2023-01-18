using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeCube : MonoBehaviour
{


    private float disappearTime;
    [SerializeField] float minDisappearTime = 1f;
    [SerializeField] float maxDisappearTime = 3f;
    [SerializeField] Texture[] brokenMaterial;


    // Start is called before the first frame update
    void Start()
    {

        disappearTime = Random.Range(minDisappearTime, maxDisappearTime);

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            Destroy(this.gameObject, disappearTime);
            this.gameObject.GetComponent<Renderer>().material.mainTexture = brokenMaterial[0];
        }
    }


}
