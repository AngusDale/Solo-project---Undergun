using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour {

    /*This script will spawn a ghost at random between 3 different locations every 7.5 seconds (or whatever is set in the inspector*/

    public Transform Spawner1, Spawner2, Spawner3;
    public GameObject ghost;
    int spawner;


    public float spawnInterval;
    float nextSpawn;

    public bool SpawnGhosts = true;
    

    // Update is called once per frame
    void Update () {
        if (SpawnGhosts == true && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnInterval;
            SpawnGhost();
            //print("Ghost spawned");
            //print(Time.time);
        }      

    }

    void SpawnGhost()
    {
        spawner = Random.Range(0, 3);

        if (spawner == 0) { Instantiate(ghost, Spawner1.position, Spawner1.rotation); }
        else if (spawner == 1) { Instantiate(ghost, Spawner2.position, Spawner1.rotation); }
        else if (spawner == 2) { Instantiate(ghost, Spawner3.position, Spawner1.rotation); }
    }
}
