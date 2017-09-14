using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
	public AudioClip musicClip;// var to hold the music clip; set within  unity
	public AudioSource musicSource;// var to hold the music's source; set within unity

	void Start()
	{
		//simply start the background music at the start of the scene
		musicSource.clip = musicClip;
		musicSource.Play();
	}
		
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			//allows us to pause the background music with the spacebar
			if (musicSource.isPlaying) {
				musicSource.Pause ();
			} else {
				musicSource.UnPause ();
			}
		}
	}
}