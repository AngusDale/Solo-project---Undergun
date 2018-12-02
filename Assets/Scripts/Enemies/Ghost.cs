using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    /*this is the script for my ghost. When it is instantiated it will travel right indefinitely unless it is hit by the player. If it hits the player it will be destroyed, the
    player will take damage and particles will be instantiated.*/

    public float speed = 10;
    public bool killable = true;

    public GameObject GhostParticles;   
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void KillGhost()
    {
        if (killable == true)
        {
            SoundManager.PlayAudio("Ghost hit");
            Instantiate(GhostParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
