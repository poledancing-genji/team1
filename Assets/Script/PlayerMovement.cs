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

    public GameObject p1;
    public GameObject p2;


    Light light1;
    Light light2;
    // Use this for initialization


    float forwardVel = 0.0f;
    bool wDown = false;
    bool aDown = false;
    bool sDown = false;
    bool dDown = false;


    void WhatsTheDamage(GameObject hitObject)
    {
        light1 = this.GetComponentInChildren(typeof(Light)) as Light;
        light2 = hitObject.GetComponentInChildren(typeof(Light)) as Light;

        Vector3 thisVectorNormal = Vector3.Normalize(this.transform.forward);
        Vector3 otherVectorNormal = Vector3.Normalize(hitObject.transform.forward);
        //Check if head-on collision
        float dot = Vector3.Dot(thisVectorNormal, otherVectorNormal);
        Vector3 p1p2 = hitObject.transform.forward - this.transform.forward;
        //Check who's being poked
        //
        float p2p1Damage = Vector3.Dot(Vector3.Normalize(p1p2), thisVectorNormal);
        float p1p2Damage = Vector3.Dot(Vector3.Normalize(p1p2), otherVectorNormal);
        Debug.Log(dot);
        Debug.Log(p1p2Damage);
        Debug.Log(p2p1Damage);
        if (dot >= 0 && dot <= 1)
        {
            Debug.Log("in head on");
            light2.range -= 1.1f;
        }
        else if (p2p1Damage > 0 && p2p1Damage <= 1)
        {
            //Current object
            Debug.Log("in 1st obj");
            light1.range -= 1.1f;
        }
        else if (p1p2Damage > 0 && p1p2Damage <= 1)
        {
            //Other object
            Debug.Log("in 2nd obj");
            light1.range -= 1.1f;
        }
    }
/*
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "player1")
        {
            velX += collision.impulse.x * -1.4f;
            velY += collision.impulse.y * -1.4f;
            playerControl = Mathf.Max(0, 1-Vector3.SqrMagnitude(collision.impulse) * 0.0125f);
            WhatsTheDamage(p2);
        }
        if (collision.gameObject.name == "player2")
        {
            velX += collision.impulse.x * 1.4f; // collision.relativeVelocity.x;
            velY += collision.impulse.y * 1.4f; // collision.relativeVelocity.y;
            playerControl = Mathf.Max(0, 1-Vector3.SqrMagnitude(collision.impulse)*0.0125f);
            WhatsTheDamage(p1);
        }
        if (collision.gameObject.tag == "wall")
        {
            collision.gameObject.GetComponent<thewallsarealsogay>().ActivateWall();
            // bounce intensity off of walls
            velX += collision.impulse.x * 0.5f;
            velY += collision.impulse.y * 0.5f;
            this.transform.position = new Vector3(this.transform.position.x + collision.impulse.x * 0.01f, this.transform.position.y + collision.impulse.y * 0.01f, this.transform.position.z);
        }
    }*/
}
