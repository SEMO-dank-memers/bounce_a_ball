using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
	public enum State {CHASING, IDLE, RETREATING }
	State currentState = new State();
	State previousState = new State();
	public GameObject rock;
	public GameObject food;
	public GameObject bug;
	public float threshhold;
	public bool atOrigin = false;
	//gets the current state that the GameObject is in
	public State getCurrentState(){
		if (currentState == State.CHASING) {
			return State.CHASING;
		} else if (currentState == State.RETREATING) {
			return State.RETREATING;
		} else {
			return State.IDLE;
		}
	}
	//changes to the last given state, this function isn't used but is good for practice
	public void ChangeToPreviousState()
	{
		State temp = currentState;
		currentState = previousState;
		previousState = temp;
	}
	//this provides the logic for when to transition from one state to the next
	public void ChangeState()
	{
		//if in idle and there is food, start chasing
		if(currentState == State.IDLE)
		{
			if (GameObject.FindWithTag ("Food")) {
					previousState = currentState;
					currentState = State.CHASING;
					setBehaviour (State.CHASING);
				}
		}
		//if in chasing and the food is eaten, change to retreating
		else if(currentState == State.CHASING)
		{
			if (!GameObject.FindWithTag ("Food")) {
				previousState = currentState;
				currentState = State.RETREATING;
				setBehaviour (State.RETREATING);
			}
		}
		//if in retreating and you have reached your origin point, change to idle
		else if(currentState == State.RETREATING)
		{
			if (atOrigin) {
				previousState = currentState;
				currentState = State.IDLE;
				setBehaviour (State.IDLE);
			}
		}
	}

	public void setBehaviour(State currentState)
	{
		if (currentState == State.IDLE) {
			setIdle ();
		} else if (currentState == State.CHASING) {
			setChasing ();
		} else if (currentState == State.RETREATING) {
			setRetreating ();
		}
	}
		
	public void setIdle()
	{
		atOrigin = false;
		currentState = State.IDLE;
		Debug.Log ("idling");
	}

	public void setChasing()
	{
		atOrigin = false;
		currentState = State.CHASING;
		Debug.Log ("chasing");
	}

	public void setRetreating()
	{
		currentState = State.RETREATING;
		Debug.Log ("retreating");
	}
}
