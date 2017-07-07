using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBall : MonoBehaviour {

	private int number = 1; // number displayed on the ball
	[SerializeField]
	private int value = 5; // points to gain when destroyed
	private TextMesh numberText;

	void Start () {
		numberText = ((this.gameObject.transform.GetChild(0)).gameObject).GetComponent<TextMesh>(); // Unity's way of getting a child object
		int index = -1;
		for (int i = 0; i < 2; i++) { // TODO make this generation more interesting
			index = Random.Range (0, GameManager.getMaxPrimes ());
			number *= GameManager.getPrime (index);
		}
		writeNumber ();
	}

	void writeNumber(){
		numberText.text = "" + number;
	}

	public int getScoreValue(){	return value; }

	public int getNumber(){ return number; }

	public void setNumber(int num){
		number = num;
		writeNumber ();
	}

}
