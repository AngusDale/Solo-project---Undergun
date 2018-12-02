using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
        
    /*
    I initially found this in a blackthorne prod tutorial (the code at the bottom of this script). However I changed it to be a series of if statements which helped me
    understand it better. I also had a bug where the player would die but it would still show them as having one heart of health. This happened because I attached 
    this script to the player game object. That meant that when I deactivated the player, the script wouldn't be able to finish. I solved this by attaching 
    this script to the Canvas which contains my heart sprites.
    */

    public GameObject player;

    int health;
    public int heartNum;

    public Image[] hearts;
    public Sprite Fheart;
    public Sprite Eheart;
    
    void Update()
    {
        PlayerEffects PE = player.GetComponent<PlayerEffects>();
        health = PE.playerHealth;        

        if (health == 3)
        {
            hearts[0].sprite = Fheart;
            hearts[1].sprite = Fheart;
            hearts[2].sprite = Fheart;
            //print(health);
        }
        else if(health == 2)
        {            
            hearts[0].sprite = Fheart;
            hearts[1].sprite = Fheart;
            hearts[2].sprite = Eheart;
            //print(health);
        }
        else if(health == 1)
        {
            hearts[0].sprite = Fheart;
            hearts[1].sprite = Eheart;
            hearts[2].sprite = Eheart;
            //print(health);
        }
        else if (health == 0)
        {
            hearts[0].sprite = Eheart;
            hearts[1].sprite = Eheart;
            hearts[2].sprite = Eheart;
            //print(health);
        }

        /*
        for (int heartIndex = 0; heartIndex < hearts.Length; heartIndex++)
        {
            if (heartIndex < health)
            {
                hearts[heartIndex].sprite = Fheart;
            }
            else
            {
                hearts[heartIndex].sprite = Eheart;                
            }
        }  
        
        if(heartIndex < heartNum)
        {
            hearts[heartIndex].enabled = true;
        }
        else
        {
            hearts[heartIndex].enabled = false;
        }*/    
    }
}
