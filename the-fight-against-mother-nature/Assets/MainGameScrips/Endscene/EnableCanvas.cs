using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableCanvas : MonoBehaviour
{
    public Canvas myCanvas;

    void Start()
    {
        myCanvas.enabled = false;
        Invoke("EnableMyCanvas", 26f);
    }

    void EnableMyCanvas()
    {
        myCanvas.enabled = true;
    }
}
