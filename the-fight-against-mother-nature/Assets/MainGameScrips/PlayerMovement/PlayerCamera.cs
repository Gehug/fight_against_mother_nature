using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private float xSens;

    [SerializeField]
    private float ySens;


    [SerializeField]
    private Transform orientation;

  
    private float xRotation;
    private float yRotation;


    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; // Zorgt er voor dat cursor is gelockt
       Cursor.visible = false; // en dat cursor is onzichtbaar
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * xSens * Time.deltaTime; // Ontvangt de muis movement om de x as
        float mouseY = Input.GetAxisRaw("Mouse Y") * ySens * Time.deltaTime; ; // Ontvangt de muis movement om de y as

        yRotation += mouseX;
        xRotation -= mouseY; // bereken rotatie angel


        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // zorgt er voor dat je maar max 90 graden naar beneden kan kijken en max 90 naar boven


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    
}
