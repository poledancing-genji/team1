using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log("asdf");
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        /*
                foreach (ContactPoint contact in collision.contacts)
                {
                    Debug.DrawRay(contact.point, contact.normal, Color.white);
                }
                if (collision.relativeVelocity.magnitude > 2)
                    audio.Play();
                    */
    }
}
