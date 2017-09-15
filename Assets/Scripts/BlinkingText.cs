using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkingText : MonoBehaviour {
	Text currentText;
	// Use this for initialization
	void Start () {
		currentText = GetComponent<Text> ();//attribute the button's text component with currentText
		StartCoroutine (Blinking ());//start the Blinking coroutine within the first frame of the game
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator Blinking(){
		bool isBlinking = true;
		while (isBlinking){
			//create blinking effect by alternating between empty text and "Press Start"
			currentText.text = "";
			yield return new WaitForSeconds (.5f);
			currentText.text = "Press Start";
			yield return new WaitForSeconds (.5f);
		}
	}
}
