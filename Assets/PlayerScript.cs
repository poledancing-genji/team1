using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
            Debug.Log(this.transform);
            this.transform.position = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y, 0);
            // rigidbody2D.velocity = new Vector2(movex * Speed, movey * Speed);
        }
	}
}
