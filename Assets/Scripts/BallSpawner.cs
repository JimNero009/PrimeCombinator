using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	private const float yPos = 4.5f; //TODO remove magic number
	[SerializeField]
	private float delay = 1.0f; // delay before creating a new object
	private Vector3 instancePos;

	public GameObject prefab = null; // Thing to instantiate. Be general now for easy extension. 

	public void CreateInstanceAfterDelay(float xPos){
		instancePos = new Vector3 (xPos, yPos);
		Invoke ("Create", delay); //TODO ensure other balls are not deleted in this time
	}

	void Create(){ // since Invoke needs a function with no arguments, define a simple function like this
		Instantiate (prefab, instancePos, Quaternion.identity);
	}
}