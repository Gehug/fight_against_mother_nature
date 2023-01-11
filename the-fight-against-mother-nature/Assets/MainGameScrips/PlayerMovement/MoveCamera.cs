using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform cameraPosition;
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = cameraPosition.position;
    }
    


    


}
