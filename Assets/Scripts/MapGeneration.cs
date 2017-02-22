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

	public int numSpawned = 0;

	// Use this for initialization
	void Start () {
		time = deltaSpawnTime - 1;

        seperatorSize = seperator.transform.localScale.x * 10;

        spawned.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
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

        Vector3 sepPos = new Vector3(dist * (10 + seperatorSize) - (5 + (seperatorSize / 2)), 0, 0);
        spawned.Add(Instantiate(seperator, sepPos, Quaternion.identity));

        GameObject tile = sections[Random.Range(0, sections.Length)];
        Vector3 tilePos = new Vector3(dist * (10 + seperatorSize), 0, 0);
        spawned.Add(Instantiate(tile, tilePos, Quaternion.identity));

		numSpawned+=4;
    }
}
