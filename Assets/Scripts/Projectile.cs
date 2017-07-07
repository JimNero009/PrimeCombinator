using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField]
	private bool isStunner = false; // stun will freeze the ball, rather than destroy it
	[SerializeField]
	private float projectileSpeed = 5;
	private int number = 1; // number value of the projectile

	void Start(){
		// Projectile is instantiated from the end of stunner/laser, so just give it some velocity here and let it go
		Rigidbody rb = this.GetComponent<Rigidbody>();
		rb.velocity = transform.forward * projectileSpeed;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "NumberBall") {
			Destroy (this.gameObject);
			GameObject hitBall = col.gameObject;

			// Now we test to see if the hit is a valid one, given the prime number and the number ball
			NumberBall nb = hitBall.GetComponent<NumberBall> ();
			int hitBallNumber = nb.getNumber();

			if (hitBallNumber % number == 0) { // if the number divides exactly
				if (isStunner) { // just stun
					hitBall.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
				} else { // actually destroy or reduce value of hit ball
					int newValue = hitBallNumber/number;
					if (newValue == 1) {
						GameObject.FindGameObjectWithTag ("Spawner").GetComponent<BallSpawner> ()
							.CreateInstanceAfterDelay (hitBall.transform.position.x);
						hitBall.GetComponent<AudioSource> ().Play (); // TODO get this to actually play something. I believe the problem is that the object
																	  // is deleted before the sound finishes playing. 
						Destroy (hitBall);
						GameManager.increaseScore (nb.getScoreValue ());
					} else {
						nb.setNumber (newValue);
					}
				}
			} else { // TODO have some cool effect or 'error' sound
			}
		} else if (col.gameObject.tag == "EndOfWorld") { // hit the back boundary or the floor
			Destroy (this.gameObject);
		}
	}

	public void setStun(bool stun){ isStunner = stun; }

	public void setPrimeNumber(int num){ number = num; }
}
