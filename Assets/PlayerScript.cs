using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour {
    Vector3 leftRotate = new Vector3(0,2,0);
    Vector3 rightRotate = new Vector3(0, -2, 0);
    Vector3 playerPos = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        playerPos.x = this.transform.position.x;
        playerPos.y = this.transform.position.y;
        playerPos.z = this.transform.position.z;
    }
    // float velX = 0.0f;
    // float velY = 0.0f;
    float forwardVel = 0.0f;
    float speedMod = 1.0f;
    bool wDown = false;
    bool aDown = false;
    bool sDown = false;
    bool dDown = false;
    // Update is called once per frame
    void Update () {
        forwardVel = forwardVel * 0.9f;
		if(Input.GetKeyDown(KeyCode.W)) {
            wDown = true;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            sDown = true;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            aDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            dDown = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            wDown = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            sDown = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            aDown = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            dDown = false;
        }

        if (wDown) {
            forwardVel += 0.025f;
        } else if (sDown)
        {
            forwardVel = forwardVel * 0.95f - 0.017f;
        }
        if (aDown && dDown)
        {
        } else if (dDown)
        {
            this.transform.Rotate(rightRotate);
        } else if (aDown)
        {
            this.transform.Rotate(leftRotate);
            // this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x-1, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        }
        //this.transform.rotation
        float dirFinal = this.transform.eulerAngles.x;
        if (this.transform.eulerAngles.y > 180)
        {
            dirFinal = 180 - dirFinal;
        }
        float velX = Mathf.Sin(dirFinal / 57.2958f) * forwardVel;
        float velY = Mathf.Cos(dirFinal / 57.2958f) * forwardVel;
        playerPos.x = playerPos.x + velX;
        playerPos.y = playerPos.y + velY;
        this.transform.position = playerPos;

    }
}
