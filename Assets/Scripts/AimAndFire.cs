using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndFire : MonoBehaviour {

	[SerializeField]
	private KeyCode fireButton; // TODO bind input more generally
	[SerializeField]
	private bool stunner = false; // Choose whether to fire stunners or destroyers

	public Projectile projectile; // Actual thing to fire
	public AudioSource fireSound;

	void Start(){
		fireSound = GetComponent<AudioSource> ();
	}

	void Update () {
		AimAtMousePosition ();
		if (Input.GetKeyDown (fireButton)) { 
			Fire ();
		}
	
	}

	void AimAtMousePosition(){
		// Raycast out to the backdrop, find the position, aim torwards it
		RaycastHit hit = hitBackdrop();
		if (!hit.collider) { Debug.Log ("Raycast hit nothing!"); return; } // should not happen within scene bounds given the geometry
		if(hit.collider.gameObject.tag == "MousePlane" || hit.collider.gameObject.tag == "NumberBall"){
			Vector3 currentTarget = hit.point;
			transform.LookAt(currentTarget);
		}
	}

	RaycastHit hitBackdrop(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		return hit;
	}

	void Fire(){
		Projectile firedProjectile = (Projectile) Instantiate (projectile, transform.position + transform.forward, transform.rotation);
		firedProjectile.setStun (stunner); // pass stun information down to the projectile object
		// Reach to the child of this object and grab the number information for the projectile
		GameObject numberText = (this.gameObject.transform.GetChild(0)).gameObject;
		firedProjectile.setPrimeNumber (numberText.GetComponent<NumberText> ().getNumber ()); // TODO is this really the smartest way to do this?
		fireSound.Play ();
	}
}
