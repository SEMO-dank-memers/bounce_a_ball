using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alternates between various food sprites whenever the AI eats the food

public class FoodControl : MonoBehaviour {
	public bool eaten = false; // set this to true in unity from any script and it will trigger the food controller
	private bool running = false; // used to ensure Update dosent cause the respawner to run multiple times at once
	public GameObject parent; //just used to get the children (in this case the food sprites) in order to alternate between them

	void Update () {
		if ((eaten == true) && (running == false)) {
			running = true;
			for(int i=0; i<7; i++){
				parent.transform.GetChild(i).gameObject.SetActive(false); // set all the food sprites to inactive state
			}
			StartCoroutine (RespawnFood ());
			}
		}
	IEnumerator RespawnFood()
	{
		int random = Random.Range(0, 6);
		yield return new WaitForSecondsRealtime(5); // let the food be inactive for 5 seconds
		parent.transform.GetChild (random).gameObject.SetActive (true); // randomly set one food sprite to active
		running = false; // allow check to run again
		eaten = false; // allow other program to cause the check to run again
	}

	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag == ("Bug")){
			eaten = true;
			Debug.Log ("Om nom nom!");
		}
	}
}
	