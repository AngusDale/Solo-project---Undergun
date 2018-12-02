using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleDespawner : MonoBehaviour {

    //This script waits 1.1 seconds after an enemy is killed and then destroys the game object. This helped with lag a fair bit.
    //The reason it is 1.1 seconds is because the particle effect that is instantiated when it is killed is 1 second long.

    float waitTime = 1.1f;
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
