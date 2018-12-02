using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    /* I learnt this code from a BlackthorneProd tutorial video. I changed the variable names, function names and made my own animation. I also put the call of this script
    inside a function whenever it is called in another script */

    public Animator cameraAnimation;

	// Use this for initialization
	public void EnemyShake()
    {
        cameraAnimation.SetTrigger("EnemyShake");
    }

    public void BulletShake()
    {
        cameraAnimation.SetTrigger("BulletShake");
    }
}
