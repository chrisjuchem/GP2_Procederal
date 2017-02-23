using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public int maxTiles;

    public GameObject seperator;
    private float seperatorSize;

    public GameObject[] sections;

    public float deltaSpawnTime;

    private ArrayList spawned = new ArrayList();
    private int dist = 1;
    private float time;

	public int numSpawned = 0; //pickups

	// Use this for initialization
	void Start () {
		//1 second delay before first spawn
		time = deltaSpawnTime - 1;

		//record info about the size of the seperator
        seperatorSize = seperator.transform.localScale.x * 10;

        spawned.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));
	}
	
	// Update is called once per frame
	void Update () {
		//account for time passing
        time += Time.deltaTime;

		// spawn if a full interval has passed
        if (time >= dist * deltaSpawnTime) {
            SpawnNext();
            dist++;
        }
	}

    void SpawnNext() { 
        //make room for the new tile and seperator
        while (spawned.Count >= maxTiles * 2 - 1) {
			Destroy(spawned[0] as GameObject);
            spawned.RemoveAt(0);
        }

		//spawn a seperator
        Vector3 sepPos = new Vector3(dist * (10 + seperatorSize) - (5 + (seperatorSize / 2)), 0, 0);
        spawned.Add(Instantiate(seperator, sepPos, Quaternion.identity));

		//Spawn a random tile
        GameObject tile = sections[Random.Range(0, sections.Length)];
        Vector3 tilePos = new Vector3(dist * (10 + seperatorSize), 0, 0);
        spawned.Add(Instantiate(tile, tilePos, Quaternion.identity));

		// 4 new pickups were spawned
		numSpawned+=4;
    }
}
