using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	private Vector3 offset;

	void Start () {
		//Initializes offset with the ofset between the camera and the player
		offset = gameObject.transform.position - PlayerPos();
	}
	
	// Update is called once per frame
	void Update () {
		SnapToPlayer ();
	}

	// Snaps the camera's position to the player's (with an offset) every frame,
	// so the camera appears to follow the player.
	void SnapToPlayer () {
		transform.position = PlayerPos() + offset; 	
	}

	// Finds the position of the player in the scene
	Vector3 PlayerPos () {
		return GameObject.FindWithTag ("Player").transform.position;
	}
}
