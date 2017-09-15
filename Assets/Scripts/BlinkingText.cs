using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkingText : MonoBehaviour {
	Text currentText;
	// Use this for initialization
	void Start () {
		currentText = GetComponent<Text> ();
		StartCoroutine (Blinking ());
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator Blinking(){
		bool isBlinking = true;
		while (isBlinking){
			currentText.text = "";
			yield return new WaitForSeconds (.5f);
			currentText.text = "Press Start";
			yield return new WaitForSeconds (.5f);
		}
	}
}
