using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {
    public GameObject leftPlatform;
    public GameObject rightPlatform;
    public GameObject player1;
    public GameObject player2;
    // Use this for initialization
    private Renderer leftPlatRender;
    private Renderer rightPlatRender;
    Color leftFinalColor = Color.green;
    Color rightFinalColor = Color.red;
    float leftColorAmt = 0.1f;
    float rightColorAmt = 0.1f;
    bool loadGameInitialized = false;
    void Start () {
        leftPlatRender = leftPlatform.GetComponent<Renderer>();
        rightPlatRender = rightPlatform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        float p1leftPlatDist = Vector3.Distance(player1.transform.position, leftPlatform.transform.position);
        float p2leftPlatDist = Vector3.Distance(player2.transform.position, rightPlatform.transform.position);
        if (p1leftPlatDist < 3)
        {
            // leftplatform becomes green when player is on it
            leftColorAmt = Mathf.Min(leftColorAmt + 0.05f, 1);
            leftFinalColor.g = leftColorAmt;
        } else
        {
            leftColorAmt = Mathf.Max(leftColorAmt - 0.05f, 0.05f);
            leftFinalColor.g = leftColorAmt;
        }

        if (p2leftPlatDist < 3)
        {
            // rightplatform becomes red when player is on it
            rightColorAmt = Mathf.Min(rightColorAmt + 0.05f, 1);
            rightFinalColor.r = rightColorAmt;
        }
        else
        {
            rightColorAmt = Mathf.Max(rightColorAmt - 0.05f, 0.05f);
            rightFinalColor.r = rightColorAmt;
        }
        leftPlatRender.material.SetColor("_EmissionColor", leftFinalColor);
        rightPlatRender.material.SetColor("_EmissionColor", rightFinalColor);
        if (leftFinalColor.g + rightFinalColor.r > 1.9f && !loadGameInitialized)
        {
            loadGameInitialized = true;
            // when both platforms are lit
            StopCoroutine("LoadGameScene");
            StartCoroutine(LoadGameScene());
        }
    }
    IEnumerator LoadGameScene()
    {
        var result = SceneManager.LoadSceneAsync("GGJGame", LoadSceneMode.Single);
        result.allowSceneActivation = false;

        while (!result.isDone)
        {
            Debug.Log("progress: " + result.progress);
            if (result.progress > 0.89f)
            {
                result.allowSceneActivation = true;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
