using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour { //dolphins
	public AudioClip musicClip;// var to hold the music clip; set within  unity
	public AudioSource musicSource;// var to hold the music's source; set within unity
	// Use this for initialization
	void Start () {
		//simply start the background music at the start of the scene
		musicSource.clip = musicClip;
		musicSource.Play();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			//allows us to pause the background music with the spacebar
			if (musicSource.isPlaying) {
				musicSource.Pause ();
			}
			else {
				musicSource.UnPause ();
			}
		}
	}
}