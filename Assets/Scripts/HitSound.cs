using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
	public AudioSource MusicSource; //var to hold the music's source; set within unity
	public AudioClip MusicClip; //var to hold the music clip; set within  unity

	void OnCollisionEnter2D(Collision2D c)
	{
		//called on Collision with a 2D rigidbody
		if (c.gameObject.name == "Ball(Clone)") { //ensures that this sound only plays when the rock's hit each other
			MusicSource.clip = MusicClip;//sets the clip the source should play
            MusicSource.Play();
        }
    }

    void Start()
	{
		//makes the collision sound for each rock slightly different
		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.pitch = Random.Range(0.8f, 1.5f);
		audioSource.Play();
	}
}
