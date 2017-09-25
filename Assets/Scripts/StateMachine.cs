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

	public State getCurrentState(){
		if (currentState == State.CHASING) {
			return State.CHASING;
		} else if (currentState == State.RETREATING) {
			return State.RETREATING;
		} else {
			return State.IDLE;
		}
	}

	public void ChangeToPreviousState()
	{
		State temp = currentState;
		currentState = previousState;
		previousState = temp;
	}

	public void ChangeState()
	{
		if(currentState == State.IDLE)
		{
			if (GameObject.FindWithTag ("Food")) {
					previousState = currentState;
					currentState = State.CHASING;
					setBehaviour (State.CHASING);
				}
		}
		else if(currentState == State.CHASING)
		{
			if (!GameObject.FindWithTag ("Food")) {
				previousState = currentState;
				currentState = State.RETREATING;
				setBehaviour (State.RETREATING);
			}
		}
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
