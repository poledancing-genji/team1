using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thewallsarealsogay : MonoBehaviour {
    public MeshRenderer wallRenderer;
    private int countInsideTrigger = 0;
    private Color groundColor;
    public RaveController r;
    void Start()
    {
        //groundColor = GameObject.Find("Ground").GetComponent<MeshRenderer>().materials[0].GetColor("_Color");
        groundColor = Color.black;
        Debug.Log(groundColor);
        r = GameObject.Find("Raver").GetComponent<RaveController>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trig");
        countInsideTrigger++;
    }

    void Update ()
    {
        Debug.Log(countInsideTrigger);
        if (countInsideTrigger > 0) { 
            wallRenderer.materials[0].SetColor("_LineColor", r.currentColor);
        } else
        {
            wallRenderer.materials[0].SetColor("_LineColor", groundColor);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("asdf");
        countInsideTrigger--;
    }
}
