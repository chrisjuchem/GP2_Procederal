using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script to move the player and detect collisions involving the player
public class Player : MonoBehaviour {

	public float speed;

    private int score;

	void FixedUpdate () {
		Move ();

		if (transform.position.y < -40) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	// Adds a force to the player according to player input
	void Move() {
		Vector3 dir = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		gameObject.GetComponent<Rigidbody> ().AddForce (dir * speed);
	}

	// Handle collisions
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
            score++;
		} 
	}
}
