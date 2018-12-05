using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    //This is my weapons script which is in charge of instantiating the bullet prefabs. It also uses a timer to set a rate of fire.
    //The weapon also triggers the shoot animation.

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate;
    private float nextFire = 0f;

    int num;

    public Animator animator;
    // Update is called once per frame
    void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            
            Shoot();
            //print("Bullet fired \n");
            
        }
	}

    //This will trigger the shoot animation as well as instantiate the bullet prefab.
    void Shoot()
    {
        animator.SetTrigger("Shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //print(bulletsFired);
        BulletShot();
    }

    void BulletShot()
    {
        num = Random.Range(0, 3);

        if (num == 0) { SoundManager.PlayAudio("Shoot Bullet"); }
        else if (num == 1) { SoundManager.PlayAudio("Shoot Bullet 2"); }
        else if (num == 2) { SoundManager.PlayAudio("Shoot Bullet 3"); }
    }
}
