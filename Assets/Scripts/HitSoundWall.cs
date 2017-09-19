using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundWall : MonoBehaviour //I know it says wall, but it's only for the floor for now, it's technically a wall.
{
	public AudioSource Source; // var to hold the audio's source; set within unity
	public AudioClip Clip; // var to hold the audio clip; set within  unity

	void OnCollisionEnter2D(Collision2D c)
	{
		//called on Collision with a 2D rigidbody
		if (c.gameObject.name == "Floor") { //ensures that this sound only plays when the rocks hit the floor (Stephen wanted it like this, so blame him if it lowers our grade)
			Source.clip = Clip; //sets the clip the source should play
			Source.Play();
            Destroy(GameObject.Find("Ball(Clone)")); //Destroys the rock when it hits the floor
		}
	}
}
