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
        string tag = collision.gameObject.tag;
        if (tag.Equals("player1") || tag.Equals("player2"))
        {
            Vector3 p1 = transform.position;
            Vector3 p2 = collision.transform.position;
            Vector3 v1 = transform.forward;
            Vector3 v2 = collision.transform.forward;

            float angleBetweenMinotaurs = Vector3.Dot(v1, v2);
            if (angleBetweenMinotaurs > 0)
            {
                Debug.Log("same dir");
                Vector3 diff = Vector3.Normalize(p2 - p1);
                float dotProd = Vector3.Dot(diff, v1);
                if (dotProd < 0)
                {
                    Light light1 = this.GetComponentInChildren(typeof(Light)) as Light;
                    light1.range -= 1.1f;
                    //TODO: play damage audio
                }
            }
            else
            {
                Debug.Log("headon");
                //TODO: play head on audio
            }
        }

        if (tag == "wall")
       {
            collision.gameObject.GetComponent<thewallsarealsogay>().ActivateWall();
       }
    }
}
