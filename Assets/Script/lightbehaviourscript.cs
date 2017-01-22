using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbehaviourscript : MonoBehaviour {
    public Light light;
    public RaveController r;

    void Start ()
    {
        r = GameObject.Find("Raver").GetComponent<RaveController>();
    }

    void Update ()
    {
        light.color = r.currentColor;
    }
}
