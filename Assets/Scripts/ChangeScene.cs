﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
	
	public void ChangesScene(string scenename){ 
		//this function is called but the button in unity when clicked it simply causes the Application to load whichever sceen is entered within the button config in unity
		//scenename is entered from unity, within the button.
		Application.LoadLevel(scenename);
	}

}