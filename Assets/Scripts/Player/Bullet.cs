using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    /*This is my bullet script. Each time a bullet prefab is spawned, this script is excecuted. The main logic behind this script came from a Brackeys youtube tutorial.  
     As usual I added things like screenshake, bullet particle effects for when it collides, and sounds for when the bullet is shot. I also changed the variables for the bullet such as it's speed and damage.
     It takes 3 hits to kill an enemy.*/

    public float bulletSpeed = 25f;
    public int bulletDamage = 1;
    private Rigidbody2D rb;

    private Shake camShake;

    public GameObject bulletBurst;
	// Use this for initialization
	void Start () {
        SoundManager.PlayAudio("Shoot Bullet");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;

        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        Physics2D.IgnoreLayerCollision(10, 11);
	}

    /*This function is from the same Brackeys tutorial that allows the enemy to take damage. I've added screen shake to my bullets as well as particle effects and sounds 
     to make it feel more impactful.*/
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            CamShake();
            enemy.EnemyDamaged(bulletDamage);
        } 
        SoundManager.PlayAudio("Bullet hits");
        Instantiate(bulletBurst, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void CamShake()
    {
        camShake.BulletShake();        
    }
}
