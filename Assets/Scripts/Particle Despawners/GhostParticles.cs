using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostParticles : MonoBehaviour {

    //This script waits 0.4 seconds after a bullet collides with an object before destroying the game object. This helped with lad a LOT! I now only have about 5 bullets
    //on screen at any one time. The reason it is 0.4 seconds is because the particle effect that is instantiated when it collides is 0.3 seconds long.

    float waitTime = 0.6f;
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
