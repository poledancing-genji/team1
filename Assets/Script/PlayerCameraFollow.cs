using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour {
    public GameObject cam;
    // Use this for initialization
    float camShiftX = 0;
    float camShiftY = 0;
    bool wDown = false;
    float camForward = 0;
    float forwardAbility = 0.2f;
    float goalCamPosX = 0;
    float goalCamPosY = 0;
    float dirGoal = 0;
    float dirFinal = 0;
    void Start () {
        dirGoal = this.transform.eulerAngles.x;
        dirFinal = this.transform.eulerAngles.x;
        goalCamPosX = this.transform.position.x;
        goalCamPosY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        dirGoal = this.transform.eulerAngles.x;
        if (this.transform.eulerAngles.y > 180)
        {
            dirGoal = 180 - dirGoal;
        }
        if (dirGoal > 180)
        {
            dirGoal -= 360;
        }
        float dirDiff = 0;
        dirDiff = dirGoal - dirFinal;
        if (dirDiff > 180)
        {
            dirDiff -= 360;
        } else if (dirDiff < -180)
        {
            dirDiff += 360;
        }
        dirFinal = dirFinal + dirDiff * 0.07f;
        if (dirFinal > 180)
        {
            dirFinal -= 360;
        } else if (dirFinal < -180)
        {
            dirFinal += 360;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            wDown = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            forwardAbility = 0.15f;
            wDown = false;
        }
        if (wDown)
        {
            forwardAbility = forwardAbility + (0.08f - forwardAbility) * 0.018f;
            camForward += forwardAbility;
        } else
        {
            forwardAbility = forwardAbility + (0.15f - forwardAbility) * 0.028f;
        }
        camForward = camForward * 0.97f;
        camShiftX = Mathf.Sin(dirFinal / 57.2958f) * camForward;
        camShiftY = Mathf.Cos(dirFinal / 57.2958f) * camForward;
        goalCamPosX = goalCamPosX * 0.1f + (this.transform.position.x + camShiftX) * 0.9f;
        goalCamPosY = goalCamPosY * 0.1f + (this.transform.position.y + camShiftY) * 0.9f;
        cam.transform.position = new Vector3(goalCamPosX, goalCamPosY, -10);
    }
}