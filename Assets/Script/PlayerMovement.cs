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


    float forwardVel = 0.0f;
    bool wDown = false;
    bool aDown = false;
    bool sDown = false;
    bool dDown = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player1")
        {
            velX += collision.impulse.x * -1.4f;
            velY += collision.impulse.y * -1.4f;
            playerControl = Mathf.Max(0, 1-Vector3.SqrMagnitude(collision.impulse) * 0.0125f);
        }
        else if (collision.gameObject.name == "player2")
        {
            velX += collision.impulse.x * 1.4f; // collision.relativeVelocity.x;
            velY += collision.impulse.y * 1.4f; // collision.relativeVelocity.y;
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

}
