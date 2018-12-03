using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    /*This is my player effects script which controls everything to do with the player aside from shooting and moving. In this script contains the player's health 
     and the controller for the player taking damaged when colliding with an enemy. I put this together using the same logic as the enemy taking damage from the bullet.
     I just switch who is taking damage and what is causing it. After play testing I also found that if I got hit by an enemy then it would be difficult for me to get away 
     without getting hit again. To solve this I added a bool variable called canTakeDamage. Read more about that above the PlayerTakeDamage function.*/

    public int playerHealth;
    [HideInInspector]
    public bool canTakeDamage = true;
    float waitTime = 0f; 
    public GameObject deathParticles;

    public bool invincible = false;

    private Shake camShake;

    public Animator animator;

    private void Start()
    {
        gameObject.SetActive(true);
        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void Update()
    {
        //print(playerHealth);
        if (waitTime <= 0)
        {
            canTakeDamage = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "MEnemy" || collision.gameObject.tag == "LEnemy")
        {            
            PlayerTakeDamage();            
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        
        Ghost ghost = hit.GetComponent<Ghost>();
        if (ghost != null && ghost.gameObject.tag == "Ghost")
        {
            //print("Ghost hit");
            PlayerTakeDamage();
            ghost.KillGhost();
            ghost.killable = false;
        }
    }

    void Animation()
    {
        camShake.EnemyShake();
        animator.SetTrigger("Damaged");
    }

    /* So here I put the canTakeDamage variable into use. When the player is about to take damage it will check to see if canTakeDamage is true. If it is then 
     the player will take damage, canTakeDamage will be set to false, and the timer will begin which counts down 1.5 seconds in the update function. 
     If the player's health is less than or equal to zero then the Die function is called. A sound plays, particles are spawned, the screenshake animation plays and the
     game object is deactivated.*/
    public void PlayerTakeDamage()
    {
        if (canTakeDamage == true && invincible == false)
        {
            Animation();
            playerHealth -= 1;
            
            canTakeDamage = false;
            waitTime = 1.5f;

            if (playerHealth <= 0)
            {
                Die();
            }
            else
            {
                SoundManager.PlayAudio("Take Damage");
            }
        }
    } 

    //This function calls the GameOver function in the MenuManager script. Then plays the death sound, then shakes the camrea, instatiates 
    //particles, and finall sets the gameobject to inactive.
    void Die()
    {
        FindObjectOfType<MenuManager>().GameOver();
        SoundManager.PlayAudio("player dies");
        camShake.EnemyShake();
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }    
}
