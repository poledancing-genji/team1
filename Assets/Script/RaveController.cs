using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaveController : MonoBehaviour {
    public Color[] colorArray;
    public int i;
    private int numColors;
    public Color currentColor;
    // Use this for initialization
    void Start () {
        numColors = colorArray.Length;
        IEnumerator coroutine = WaitAndGay(0.5f);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndGay(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            currentColor = colorArray[i];
            i++;
            i = i % numColors;
        }
    }
}
