using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWall : MonoBehaviour {
    public GameObject collideables;
    // float playerSize = 0.5f;
    // Use this for initialization
    void Start () {
		
	}

        // Update is called once per frame

        /*
         * void Update () {
            foreach (Transform child in collideables.transform)
            {
                float xPos = this.transform.position.x;
                float yPos = this.transform.position.y;
                float xChildPos = child.position.x;
                float yChildPos = child.position.y;
                float childRightMost = xChildPos + child.localScale.x * 0.5f;
                float childleftMost = xChildPos - child.localScale.x * 0.5f;
                float childTopMost = yChildPos + child.localScale.y * 0.5f;
                float childBotMost = yChildPos - child.localScale.y * 0.5f;

                if (xPos - playerSize < childRightMost && xPos + playerSize > childleftMost && yPos - playerSize < childTopMost && yPos + playerSize > childBotMost)
                {
                };

                // child.position.x;
                // Something(child.gameObject);
            }
        }
        */
    }
