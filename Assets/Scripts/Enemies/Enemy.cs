using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    /*This is my enemy script which controlls everything but the enemies movement. This script allows them to die and take damage and play the appropriate sounds.
     The TakeDamage function that I have was found in a Brackeys tutorial which shows how to shoot a projectile and have the enemy take damage. I have added sounds and particle
     effects to all of my assets to give them a better game feel.*/

    public int pointsValue;
    public int healthMin;
    public int healthMax;
    int health;
    public int enemyDamage = 1;
    public GameObject deathParticles;
    public GameObject spawnParticles;
    
    private Shake camShake;
    public bool shakeScreen;
    
    void Start()
    {
        print("points value " + pointsValue);
        Instantiate(spawnParticles, transform.position, transform.rotation);
        health = Random.Range(healthMin, healthMax + 1);
        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();        
    }

    public void EnemyDamaged(int bulletdamage)
    {       
        health -= bulletdamage;
        //print("enemy damaged \n");    

        if (health <= 0)
        {
            KillEnemy();              
        }
        else
        {
            DamagedSound();
        }       
    }    

    void KillEnemy()
    {
        FindObjectOfType<Score>().killScore += pointsValue;
        FindObjectOfType<Score>().killCount++;
        SoundManager.PlayAudio("Enemy Dies");
        if (shakeScreen == true)
        {
            camShake.EnemyShake();
        }    
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }   

    /*I have used another random number generator to randomly decide between three different damaged sounds. This allows each hit o an enemy to feel unique 
     * and prevents the audio from becoming stale and boring.*/

    void DamagedSound()
    {
        int damaged = Random.Range(0, 3);

        if (damaged == 0)
        {
            SoundManager.PlayAudio("Enemy Damaged 1");
        }
        else if (damaged == 1)
        {
            SoundManager.PlayAudio("Enemy Damaged 2");
        }
        else if (damaged == 2)
        {
            SoundManager.PlayAudio("Enemy Damaged 3");
        }
    }
}

    

