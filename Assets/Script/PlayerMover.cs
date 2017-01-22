using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    public Rigidbody playerBody;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public float speed;
    public float angularSpeed;

    void FixedUpdate() {
       if (Input.GetKey(up))
        {
            Vector3 forward = speed * transform.forward;
            playerBody.AddForce(forward);
        } else if (Input.GetKey(down))
        {
            Vector3 backward = -1 * speed * transform.forward;
            playerBody.AddForce(backward);
        }

        if (Input.GetKey(right))
        {
            transform.Rotate(-1 * Vector3.up * angularSpeed);
        }
        else if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.up * angularSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "wall")
       {
            collision.gameObject.GetComponent<thewallsarealsogay>().ActivateWall();
        }
    }
}
