using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeCube : MonoBehaviour
{


    private float disappearTime;
    [SerializeField] float minDisappearTime = 1f;
    [SerializeField] float maxDisappearTime = 3f;
    [SerializeField] Texture[] brokenMaterial;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {

        disappearTime = Random.Range(minDisappearTime, maxDisappearTime);
        rb = GetComponent<Rigidbody>();





    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            Invoke(nameof(DestroyCube), disappearTime);
            this.gameObject.GetComponent<Renderer>().material.mainTexture = brokenMaterial[0];
        }
    }



    //void LetObjectFall()
    //{
    //    print("useGravity on");
    //    rb.useGravity = true;
    //    rb.constraints = RigidbodyConstraints.None;

    //    Invoke(nameof(DestroyCube), 0.3f);

    //}


    void DestroyCube()
    {
        Destroy(this.gameObject);
    }
}
