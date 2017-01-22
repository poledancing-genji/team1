using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public AudioSource audioSource;
    public AudioSource music;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;
    public GameObject wall6;
    int counter = 100;
    float remainingDelay = 6.2f;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (remainingDelay < 0)
        {
            // unfreeze
            if (counter > 0)
            {
                counter--;
                wall1.transform.Translate(0, 1, 0);
                wall2.transform.Translate(0, 1, 0);
                wall3.transform.Translate(0, 1, 0);
                wall4.transform.Translate(0, 1, 0);
                wall5.transform.Translate(0, -1, 0);
                wall6.transform.Translate(0, -1, 0);
            }
        } else
        {
            remainingDelay -= Time.deltaTime;
        }
        if (!audioSource.isPlaying && !music.isPlaying)
        {
            music.Play();
        }
    }
}
