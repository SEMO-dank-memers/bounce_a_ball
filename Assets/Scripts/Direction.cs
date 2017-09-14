using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
	public float thrust; //allows us to set the ammount that we increase the rock's speed by within unity
	public Rigidbody2D rigidBody;//allows us to set which object to manipulate within unity

	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();//grabs the Rigidbody2D component of the object specified within unity
		rigidBody.AddForce (transform.up * thrust);//add upward force to the rock
		Quaternion rotation = transform.rotation;
		transform.Rotate(Vector3.forward, Random.Range(0,360));//rotate the rock in a random direction
	}

	// Update is called once per frame
	void Update()
	{
		Quaternion rotation = transform.rotation;
		transform.Rotate(Vector3.forward, 5);//rotate the rock slightly in each frame
	}

	void OnCollisionEnter2D()
	{
		rigidBody = GetComponent<Rigidbody2D>();

		if (rigidBody.velocity.magnitude < 0.01) {
			rigidBody.AddForce (transform.up * thrust);//increase rock's speed if it has slown down too much after the collision
		}

		Quaternion rotation = transform.rotation;
		transform.Rotate(Vector3.forward, Random.Range(0,360));//randomly rotate the rocks after a collision
	}
}
