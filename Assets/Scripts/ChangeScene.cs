using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
	public void ChangesScene(string scenename){
		Application.LoadLevel(scenename);
	}
}