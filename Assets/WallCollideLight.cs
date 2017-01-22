using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollideLight : MonoBehaviour
{
    //MeshRenderer wallRenderer;

    // Use this for initialization
    void Start()
    {
        //wallRenderer = this.GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(wallRenderer.materials[0].GetColor("_LineColor").a);
    }
}
