﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    /*This is my enemy movement script without the patrol feature. I found that enemies refusing to go off the edge of a platform caused lock ups.
    To further reduce lock ups I added a feature that will change an enemies direction at random. Seeing as I have lots of enemies, I also added a feature that 
    an enemy will change direction if they collide with another enemy or the player.*/

    public float enemySpeed;

    private void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            ChangeDirection();
        }
    }


    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "wall")
        {            
            ChangeDirection();            
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transporter 1")
        {
            transform.position = new Vector3(-12, 16f, 0f);
        }
        else if (collision.gameObject.tag == "Transporter 2")
        {
            transform.position = new Vector3(27, 16f, 0f);
        }
    }

    public void ChangeDirection()
    {   
        transform.Rotate(0f, 180f, 0f);
        //print("Changing direction");
    }
}
