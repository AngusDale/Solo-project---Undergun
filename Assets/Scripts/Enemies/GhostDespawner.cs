using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDespawner : MonoBehaviour {

    //This script despawns the ghost after 7.4 seconds if it isn't hit by the player

    float waitTime = 7.4f;
    // Use this for initialization
    void Update()
    {


        if (waitTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

    }
}
