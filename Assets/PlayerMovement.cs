using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour {
    Vector3 rotateVec = new Vector3(0,0,0);
    float rotateSpeed = 0;
    Vector3 playerPos = new Vector3(0, 0, 0);
    Vector3 playerVel = new Vector3(0, 0, 0);
    public Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        playerPos.x = this.transform.position.x;
        playerPos.y = this.transform.position.y;
        playerPos.z = this.transform.position.z;
    }

    float forwardVel = 0.0f;
    bool wDown = false;
    bool aDown = false;
    bool sDown = false;
    bool dDown = false;
    // Update is called once per frame
/*    void FixedUpdate()
    {
        rb.AddForce(1, 1, 1, ForceMode.Impulse);
    }
    */
    void Update () {
        rotateVec.y = 0;// rotateVec.y * 0.8f;
        forwardVel = forwardVel * 0.95f;
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
            forwardVel += 0.25f;
        } else if (sDown)
        {
            forwardVel = forwardVel * 0.95f - 0.17f;
        }
        if (aDown && dDown)
        {
        } else if (dDown)
        {
            rotateSpeed = -5f;
        } else if (aDown)
        {
            rotateSpeed = 5f;
        }
        if (wDown || sDown)
        {
            rotateSpeed = rotateSpeed * 0.25f;
        }
        rotateVec.y = rotateVec.y + rotateSpeed;
        Debug.Log(rotateSpeed);
        rotateSpeed = rotateSpeed * 0.85f;
        if (Mathf.Abs(rotateSpeed) < 0.7f)
        {
            rotateSpeed = 0;
        }
        this.transform.Rotate(rotateVec);
        if (Mathf.Abs(rotateVec.y) < 0.5f)
        {
            rotateVec.y = 0;
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
        playerVel.x = velX;
        playerVel.y = velY;
        // this.transform.position = playerPos;
        rb.velocity = playerVel;
        rb.AddForce(velX, velY, 0, ForceMode.VelocityChange);
    }
}
