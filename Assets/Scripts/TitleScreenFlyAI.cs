using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenFlyAI : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	private Collision2D dangerZone; //detection circle for the fly to know to change directions
	public Transform fly;

	//initialization
	void Start()
	{
		float x = Random.Range(-100, 100); //decide a random x
		float y = Random.Range(-100, 100); //decide a random y
		x /= 100; y /= 100; //set them to a usable float
		rb = GetComponent<Rigidbody2D>();

		Vector2 dir = new Vector2(x, y); //create the direction vector
		dir *= speed; //add the speed
		rb.velocity = dir; //set sail for adventure!
	}

	void OnTriggerEnter2D(Collider2D other) {
		Vector2 thisPos = transform.position; //the fly's position
		Vector2 otherPos = other.transform.position; //the object "hostile to the fly"'s position
		Vector2 newPos = thisPos - otherPos; //a new position

		float x, y;

		//You say: "We've added AI to our program!"
		//I hear: "We've added a ton of if statements to our program!"
		if (other.tag == "LeftWall") { //if it's abouta hit that left wall
			x = Random.Range(30, 70); //right x axis
			y = Random.Range(-80, 80); //anywhere y axis
		} else if (other.tag == "RightWall") { //if it's abouta hit that right wall
			x = Random.Range(-70, -30); //left x axis
			y = Random.Range(-80, 80); //anywhere y axis
		} else if (other.tag == "TopWall") { //if it's abouta hit that top wall
			y = Random.Range(-70, -30); //down y axis
			x = Random.Range(-80, 80); //anywhere x axis
		} else if (other.tag == "BottomWall") { //if it's abouta hit that bottom wall
			y = Random.Range(30, 70); //up y axis
			x = Random.Range(-80, 80); //anywhere x axis
		} else {
			if (newPos.x >= 0) { //if the object's x is to our left
				x = Random.Range(30, 70); //we move somewhere right
			} else { //the object's x is to our right
				x = Random.Range(-70, -30); //we move somewhere left
			}

			if (newPos.y >= 0) { //if the object's y is below us
				y = Random.Range(30, 70); //we move somewhere above
			} else { //the object's y is above us
				y = Random.Range(-70, -30); //we move somewhere below
			}
		}

		x /= 100; //turn into a valid float vector
		y /= 100;

		rb.velocity = new Vector3(0, 0, 0);

		Vector2 dir = new Vector2(x, y);
		dir *= speed;
		rb.velocity = dir;
	}

	void Update()
	{

	}
}
