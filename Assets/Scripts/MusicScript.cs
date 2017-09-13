﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {
	public AudioClip musicClip;
	public AudioSource musicSource;
	// Use this for initialization
	void Start () {
		musicSource.clip = musicClip;
		musicSource.Play();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			if (musicSource.isPlaying) {
				musicSource.Pause ();
			}
			else {
				musicSource.UnPause ();
			}
		}
	}
}