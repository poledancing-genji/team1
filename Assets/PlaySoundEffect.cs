using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour {

    public AudioSource source;
    public AudioClip[] sfx = new AudioClip[12];
    int myIndex = 0;
    
	// Use this for initialization
	public void PlaySFX()
    {
        source.clip = sfx[myIndex];
        if (myIndex  >= 11)
        {
            myIndex = 0;
        }
        else
        {
            myIndex += 1;
        }
        source.Play();
    }
}
