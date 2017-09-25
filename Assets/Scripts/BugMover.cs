using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMover : MonoBehaviour {
	private bool hitByRock;
	StateMachine stateMachine = new StateMachine();
	public float speed;
	Vector2 waypoint = new Vector2 ();
	// Use this for initialization
	void Start () {
		stateMachine.setBehaviour (StateMachine.State.IDLE);
		setNewWayPoint ();
	}

	// Update is called once per frame
	void Update () {
		stateMachine.ChangeState ();
		float step = speed * Time.deltaTime;
		if (stateMachine.getCurrentState() == StateMachine.State.CHASING) {
			Vector2 foodPosition = new Vector2 (0, -3.5f);
			transform.position = Vector2.MoveTowards(transform.position, foodPosition, step);
		}
		else if(stateMachine.getCurrentState() == StateMachine.State.RETREATING){
			Vector2 home = new Vector2(6.0f,3.5f);
			transform.position = Vector2.MoveTowards(transform.position, home, step);
			if (gameObject.transform.position.x >= home.x && gameObject.transform.transform.position.y >= home.y) {
				stateMachine.atOrigin = true;
			}
		}
		else if(stateMachine.getCurrentState() == StateMachine.State.IDLE){
			if (gameObject.transform.position.x == waypoint.x && gameObject.transform.position.y == waypoint.y) {
				setNewWayPoint ();
			}
			transform.position = Vector2.MoveTowards(transform.position, waypoint, step);
		}
		var transformer = gameObject.transform.localScale;
		if (gameObject.transform.position.x < 0) {
			transformer.x = -2;
		} else {
			transformer.x = 2;
		}
		transform.localScale = transformer;
		if (hitByRock) {
			Destroy (this.gameObject);
			Debug.Log("hit by rock");
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.name == ("Ball(Clone)")) {
			hitByRock = true;
		} else if (c.gameObject.tag == ("Food")) {
			GameObject food = GameObject.FindWithTag ("Food");
			Destroy (food); //om nom nom
		}
	}

	void setNewWayPoint(){
		waypoint.x = Random.Range(-6.5f,6.5f);
		waypoint.y = Random.Range(-2.0f,4.0f);
	}
}
