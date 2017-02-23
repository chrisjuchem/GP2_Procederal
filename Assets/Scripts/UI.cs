using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Player player;
	public MapGeneration spawner;

	//Update the score text
	void Update () {
		gameObject.GetComponent<Text>().text = player.score + "/" + spawner.numSpawned;
	}
}
