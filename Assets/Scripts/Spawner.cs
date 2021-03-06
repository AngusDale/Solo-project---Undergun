﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    /*The time that spawns enemies was found in a Brackeys youtube tutorial. However it contained a for loop that wasn't needed so I removed it. It would cause enemies to spawn
    endlessly. To develop this spawning feature I added in different spawn points that generate 10 enemies altogether. Once 10 enemies have spawned then spawning will stop.
    While testing this I also found that there was a high potential for lockup on the two top platforms. To solve this I made it so that once an enemy spawned at one of
    those locations, the spawner would deactivate.
    
    I also added a big change to how spawnWave works. When it starts spawning enemies, they will spawn every 1.5 seconds. Once 15 enemies have spawned the time between 
    spawns will decrease to 0.75. */

    public GameObject SEnemy;
    public GameObject MEnemy;
    public GameObject LEnemy;
    public GameObject enemiesLeftGO;

    public int waveSize;
    private int enemysSpawned = 0;
    private int spawner = 0;
    private int enemySize;
    private int changeRate;
    private int changeRate2;

    /*PrimarySpawnRate is the spawnrate for the first half of the wave. SecondarySpawnRate is the spawnrate for the second half of the wave. changeRate is the trigger for the spawn
     * rate to change and will always be a third of the way through an enemy wave. Wave size is the amount of enemies total.*/

    public float primarySpawnRate = 1.5f;
    public float secondarySpawnRate = 0.75f;
    public float tertiarySpawnRate = 0.5f;
    private float enemyInterval = 1;
    private float nextEnemy = 0f;

    public Transform spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint6;

    public bool spawning = true;

    private void Start()
    {
        changeRate = waveSize / 3;
        changeRate2 = changeRate * 2;

        //print(changeRate + " " + changeRate2);
    }

    void Update ()
    {
        if (spawning == true && enemysSpawned < waveSize)
        {
            SpawnWave();
        }
    }
    
    //This will spawn Small, medium and large enemies at a ratio of 10:3:1. To acomplish this I set different if statement parameters for each 
    //enemy along with a random number generator. This function will also change the spawn rate after a certain number of enemies has spawned
    //in order to create a very simple negative feedback loop. I.e. if the player is doing better, the game gets harder.
    void SpawnWave()
    {
        //print(enemySize);
        if (Time.time > nextEnemy && enemysSpawned < waveSize)
        {
            nextEnemy = Time.time + enemyInterval;
            ChooseEnemy();

            enemysSpawned++;
            if (enemysSpawned <= changeRate)
            {
                enemyInterval = primarySpawnRate;
                //print("Enemy Spawned 1");
            }
            else if (enemysSpawned > changeRate && enemysSpawned <= changeRate2)
            {
                enemyInterval = secondarySpawnRate;
                print("Enemy Spawned 2");
            }
            else if (enemysSpawned > changeRate2)
            {
                enemyInterval = tertiarySpawnRate;
                print("Enemy Spawned 3");
            }

            //print("Enemy Interval: " + enemyInterval);
            //print("Enemy Spawned");
        }          
            
            //print(enemyInterval);
       }

    void ChooseEnemy()
    {
        enemySize = Random.Range(0, 15);
        if (enemySize == 0) { SpawnLarge(); }
        else if (enemySize > 0 && enemySize < 4) { SpawnMedium(); }
        else if (enemySize >= 4) { SpawnSmall(); }
    }
    
    
    void SpawnSmall()
    {
        //I'm using a random number generator to randomly choose a spawner in which to spawn an enemy at. 
                
        spawner = Random.Range(0, 4);
        if      (spawner == 0) { Instantiate(SEnemy, spawnPoint1.position, spawnPoint1.rotation); }
        else if (spawner == 1) { Instantiate(SEnemy, spawnPoint2.position, spawnPoint2.rotation); }
        else if (spawner == 2) { Instantiate(SEnemy, spawnPoint3.position, spawnPoint3.rotation); }
        else if (spawner == 3) { Instantiate(SEnemy, spawnPoint6.position, spawnPoint6.rotation); }
    }

    void SpawnMedium()
    {
        spawner = Random.Range(0, 4);
        if      (spawner == 0) { Instantiate(MEnemy, spawnPoint1.position, spawnPoint1.rotation); }
        else if (spawner == 1) { Instantiate(MEnemy, spawnPoint2.position, spawnPoint2.rotation); }
        else if (spawner == 2) { Instantiate(MEnemy, spawnPoint3.position, spawnPoint3.rotation); }
        else if (spawner == 3) { Instantiate(MEnemy, spawnPoint6.position, spawnPoint6.rotation); }
    }

    void SpawnLarge()
    {
        spawner = Random.Range(0, 4);
        if      (spawner == 0) { Instantiate(LEnemy, spawnPoint1.position, spawnPoint1.rotation); }
        else if (spawner == 1) { Instantiate(LEnemy, spawnPoint2.position, spawnPoint2.rotation); }
        else if (spawner == 2) { Instantiate(LEnemy, spawnPoint3.position, spawnPoint3.rotation); }
        else if (spawner == 3) { Instantiate(LEnemy, spawnPoint6.position, spawnPoint6.rotation); }
    }
    
}

