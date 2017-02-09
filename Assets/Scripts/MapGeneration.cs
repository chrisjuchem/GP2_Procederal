﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public int maxTiles;

    public GameObject seperator;
    public float seperatorSize;

    public GameObject[] sections;

    public float deltaSpawnTime;

    public ArrayList spawned = new ArrayList();
    private int dist = 1;
    private float time = 0;


	// Use this for initialization
	void Start () {
        seperatorSize = seperator.transform.localScale.z * 10;

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
        while (spawned.Count > maxTiles * 2) {
            (spawned[0] as GameObject).SetActive(false);
            spawned.RemoveAt(0);
        }

        Vector3 sepPos = new Vector3(0, 0, dist * (10 + seperatorSize) - (5 + (seperatorSize / 2)));
        spawned.Add(Instantiate(seperator, sepPos, Quaternion.identity));

        GameObject tile = sections[Random.Range(0, sections.Length)];
        Vector3 tilePos = new Vector3(0, 0, dist * (10 + seperatorSize));
        spawned.Add(Instantiate(tile, tilePos, Quaternion.identity));

    }
}
