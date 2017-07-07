using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberText : MonoBehaviour {

	private TextMesh numberText;
	[SerializeField]
	private int index = 0; // index into an array of primes, to be dislayed on the shooter
	private int maxIndex = GameManager.getMaxPrimes(); // used to wrap index around
	[SerializeField]
	private KeyCode changePrime; // TODO bind input more generally

	void Start () {
		numberText = GetComponent<TextMesh> ();
		writeNumber ();
	}

	void Update(){
		if (Input.GetKeyDown (changePrime)) {
			index++;
			writeNumber ();
		}
	}

	void writeNumber(){
		index %= maxIndex;
		numberText.text = "" + GameManager.getPrime(index); // TODO make text more visible when objects are pointed at extreme angles
	}

	public int getNumber() { return GameManager.getPrime (index); }

}
