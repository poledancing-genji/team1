using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {

    public AudioSource[] musicTracks;
    public int currentIndex = 0;
	// Update is called once per frame

    void Awake()
    {
        musicTracks[currentIndex].Play();
    }
	void Update () {
		// get player health
        if (!musicTracks[currentIndex].isPlaying) {
            if (currentIndex < 2)
            {
                currentIndex += 1;
            } else
            {
                currentIndex = 0;
            }
            musicTracks[currentIndex].Play();
        }
        
	}
}
