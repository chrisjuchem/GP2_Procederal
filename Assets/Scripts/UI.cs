using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Player player;
	public MapGeneration spawner;
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = player.score + "/" + spawner.numSpawned;
	}
}
