using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {
	public float thrust;
	public Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.AddForce (transform.up * thrust);
		Quaternion rotation = transform.rotation;
		transform.Rotate(Vector3.forward, Random.Range(0,360));
	}

	// Update is called once per frame
	void Update () {
        Quaternion rotation = transform.rotation;
        transform.Rotate(Vector3.forward, 5);
    }

	void OnCollisionEnter2D(){
		rigidBody = GetComponent<Rigidbody2D>();
		if (rigidBody.velocity.magnitude < 0.01) {
			rigidBody.AddForce (transform.up * thrust);
		}
		Quaternion rotation = transform.rotation;
		transform.Rotate(Vector3.forward, Random.Range(0,360));
	}
}
