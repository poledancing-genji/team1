using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thewallsarealsogay : MonoBehaviour
{
    public MeshRenderer wallRenderer;
    public RaveController r;
    float initialFadeSpeed = 0.00005f;
    float fadeSpeed = 0.00005f;
    float fadeAcc = 0.00001f;
    void Start()
    {
        //groundColor = GameObject.Find("Ground").GetComponent<MeshRenderer>().materials[0].GetColor("_Color");
        r = GameObject.Find("Raver").GetComponent<RaveController>();
    }

    public void ActivateWall()
    {
        StopCoroutine("pulse");
        StartCoroutine(pulse());
    }

    IEnumerator pulse()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            Color currColor = r.currentColor;
            float resultantAlpha = Mathf.Max(wallRenderer.materials[0].GetColor("_LineColor").a - fadeSpeed, alpha);
            currColor.a = resultantAlpha;
            wallRenderer.materials[0].SetColor("_LineColor", currColor);
            alpha -= fadeSpeed;
            fadeSpeed += fadeAcc;
            yield return null;
        }
        fadeSpeed = initialFadeSpeed;
    }
}
