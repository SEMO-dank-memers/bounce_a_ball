using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
	public GameObject objectToSpawn; //allows us to specify what to spawn within unity

	void Update()
	{
        if (GameObject.Find("Ball(Clone)") == null) //Makes sure only one rock is created
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate the cords of the mouse to a ingame point
                spawnPosition.z = 0.0f;
                Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0))); //spawn the ball at the cords of the found ingame point
            }
        }
	}
}