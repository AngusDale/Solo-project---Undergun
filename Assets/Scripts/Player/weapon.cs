using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate;
    private float nextFire = 0f;

    public int bulletsFired = 1;

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

    
    void Shoot()
    {
        bulletsFired++;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //print(bulletsFired);
    }
}
