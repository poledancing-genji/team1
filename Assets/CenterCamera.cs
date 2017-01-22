using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCamera : MonoBehaviour {
    public GameObject obj1;
    public GameObject obj2;
    public Camera cam;
    float distApart = 0;
    float camGoalDist = 5;
    Vector3 camGoalPos = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        this.transform.position = (obj1.transform.position + obj2.transform.position) / 2;
        camGoalPos = cam.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = (obj1.transform.position + obj2.transform.position) / 2;
        distApart = 1+Vector3.Distance(this.transform.position, obj1.transform.position);
        camGoalPos = this.transform.position;
        camGoalPos.z = -10;
        float distDiff = camGoalDist - distApart;
        if (distApart < camGoalDist && camGoalDist < 8)
        {
            // final zoom in slower
            camGoalDist = camGoalDist - distDiff*Mathf.Min(1, (camGoalDist - Mathf.Max(4, distDiff))*0.25f);
        }
        else
        {
            camGoalDist = camGoalDist - distDiff;
        }

        cam.transform.position = camGoalPos;
        cam.orthographicSize = Mathf.Max(4, camGoalDist);
    }
}
