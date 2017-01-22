using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    Vector3 rotateVec = new Vector3(0,0,0);
    float rotateSpeed = 0;
    float velX = 0;
    float velY = 0;
    float playerControl = 1;
    public bool ASDF;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player1")
        {
            velX += collision.impulse.x * -1; // collision.relativeVelocity.x;
            velY += collision.impulse.y * -1; // collision.relativeVelocity.y;
            playerControl = Mathf.Max(0, 1-Vector3.SqrMagnitude(collision.impulse) * 0.0125f);
        }
        else if (collision.gameObject.tag == "player2")
        {
            velX += collision.impulse.x * 1; // collision.relativeVelocity.x;
            velY += collision.impulse.y * 1; // collision.relativeVelocity.y;
            playerControl = Mathf.Max(0, 1-Vector3.SqrMagnitude(collision.impulse)*0.0125f);
        }
        else if (collision.gameObject.tag == "wall")
        {
            collision.gameObject.GetComponent<thewallsarealsogay>().ActivateWall();
            // bounce intensity off of walls
            velX += collision.impulse.x * 0.5f;
            velY += collision.impulse.y * 0.5f;
            this.transform.position = new Vector3(this.transform.position.x + collision.impulse.x * 0.01f, this.transform.position.y + collision.impulse.y * 0.01f, this.transform.position.z);
        }
    }

    void Update () {
        playerControl = Mathf.Min(1, playerControl + 0.025f);
        rotateVec.y = 0;// rotateVec.y * 0.8f;
        forwardVel = forwardVel * 0.95f;
        if (ASDF)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                wDown = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                sDown = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                aDown = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
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
        } else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                wDown = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                sDown = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                aDown = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                dDown = true;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                wDown = false;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                sDown = false;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                aDown = false;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                dDown = false;
            }
        }

        if (wDown) {
            forwardVel += 0.1f*playerControl;
        } else if (sDown)
        {
            forwardVel = forwardVel - 0.05f;
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
        velX = velX * 0.93f;// + Mathf.Sin(dirFinal / 57.2958f) * forwardVel;
        velY = velY * 0.93f;// + Mathf.Cos(dirFinal / 57.2958f) * forwardVel;
        if (wDown || sDown)
        {
            velX = velX + Mathf.Sin(dirFinal / 57.2958f) * forwardVel;
            velY = velY + Mathf.Cos(dirFinal / 57.2958f) * forwardVel;
        }
        float speed = Mathf.Sqrt(velX * velX + velY * velY);
        if (speed > 9)
        {
            velX = velX * (1 - (speed - 9) / 9);
            velY = velY * (1 - (speed - 9) / 9);
        }
        playerPos.x = playerPos.x + velX;
        playerPos.y = playerPos.y + velY;
        playerVel.x = velX;
        playerVel.y = velY;
        // this.transform.position = playerPos;
        rb.velocity = playerVel;
        rb.AddForce(velX, velY, 0, ForceMode.VelocityChange);
    }
}
