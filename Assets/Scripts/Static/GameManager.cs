using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public static class GameManager {

	private static int score = 0;
	private static int[] primes = { 2, 3, 5, 7 }; // the prime numbers we can shoot with

	public static void increaseScore(int amount){
		GameObject scoreTextObject = GameObject.FindWithTag ("ScoreText");
		score += amount;
		Text scoreText = scoreTextObject.GetComponent<Text> ();
		scoreText.text = "Score: " + score;
	}

	public static int getPrime(int index){ return primes [index]; }

	public static int getMaxPrimes(){ return primes.Length; }

	// TODO implement a max score or other win condition
	// TODO implement more challenging gameplay
	// TODO play with idea of balls moving towards the player
	// TODO explore gameplay with stunning projectiles too
}
