using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //This sound manager was found in a youtube tutorial by Alexander Zotov. 
    //I've put in all my own sounds and have called them from different scripts when necessary.

    public static AudioClip ghostHit, bulletHits, enemyDamaged1, enemyDamaged2, enemyDamaged3, enemyDies, jump1, jump2, jump3, playerDies, shootBullet, takeDamage;
    static AudioSource source;

	// Use this for initialization
	void Start () {

        //This is assigning a sound from my resources folder to a variable that we establish above.
        
        ghostHit = Resources.Load<AudioClip>("Ghost hit");
        bulletHits = Resources.Load<AudioClip>("Bullet hits");
        enemyDamaged1 = Resources.Load<AudioClip>("Enemy Damaged 1");
        enemyDamaged2 = Resources.Load<AudioClip>("Enemy Damaged 2");
        enemyDamaged3 = Resources.Load<AudioClip>("Enemy Damaged 3");
        enemyDies = Resources.Load<AudioClip>("Enemy Dies");
        jump1 = Resources.Load<AudioClip>("Jump 1");
        jump2 = Resources.Load<AudioClip>("Jump 2 new");
        jump3 = Resources.Load<AudioClip>("Jump 2");
        playerDies = Resources.Load<AudioClip>("player dies");
        shootBullet = Resources.Load<AudioClip>("Shoot Bullet");
        takeDamage = Resources.Load<AudioClip>("Take Damage");

        source = GetComponent<AudioSource>();

    }	

    //This is my first time using the switch method. My understanding is that, when a sound is called  from a script it will correspond to one of the strings below. 
    //'Case' is checking to see if the sound that was called is equal to the strings stated below.
    public static void PlayAudio (string audClip)
    {
        switch (audClip)
        {
            case "Ghost hit":
                source.PlayOneShot(ghostHit);
                break;
            case "Bullet Hits":
                source.PlayOneShot(bulletHits);
                break;
            case "Enemy Damaged 1":
                source.PlayOneShot(enemyDamaged1);
                break;
            case "Enemy Damaged 2":
                source.PlayOneShot(enemyDamaged2);
                break;
            case "Enemy Damaged 3":
                source.PlayOneShot(enemyDamaged3);
                break;
            case "Enemy Dies":
                source.PlayOneShot(enemyDies);
                break;
            case "Jump 1":
                source.PlayOneShot(jump1);
                break;
            case "Jump 2":
                source.PlayOneShot(jump2);
                break;
            case "Jump 3":
                source.PlayOneShot(jump3);
                break;
            case "player dies":
                source.PlayOneShot(playerDies);
                break;
            case "Shoot Bullet":
                source.PlayOneShot(shootBullet);
                break;
            case "Take Damage":
                source.PlayOneShot(takeDamage);
                break;
        }
    }
}
