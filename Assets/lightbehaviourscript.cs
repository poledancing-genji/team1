using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbehaviourscript : MonoBehaviour {

// Use this for initialization
    public GameObject player;
    public Vector3 lightPos = new Vector3(0, 0, 0);
    public Color[] colorArray;
    public int i;
    private int numColors;
    private IEnumerator coroutine;
void Start () {
        player = GameObject.FindGameObjectWithTag("player1");
        lightPos.x = player.transform.position.x;
        lightPos.y = player.transform.position.y;
        lightPos.z = player.transform.position.z;
        this.transform.position = lightPos;
        numColors = colorArray.Length;

        //coroutine
        coroutine = WaitAndGay(0.5f);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndGay(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            this.GetComponent<Light>().color = colorArray[i];
            i++;
            i = i % numColors;
        }
    }
	
// Update is called once per frame
void Update () {
        lightPos.x = player.transform.position.x;
        lightPos.y = player.transform.position.y;
        this.transform.position = lightPos;		
}
}
