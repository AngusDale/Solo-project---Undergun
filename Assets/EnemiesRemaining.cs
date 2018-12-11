using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesRemaining : MonoBehaviour {

    
    int enemiesLeftInt;
    public Text enemiesLeft;
    
    public GameObject enemySpawner;

	// Use this for initialization
	void Start () {
        Spawner spawn = enemySpawner.GetComponent<Spawner>();
        enemiesLeftInt = spawn.waveSize;
        enemiesLeft.text = enemiesLeftInt.ToString();
    }

    public void ChangeText()
    {
        enemiesLeftInt--;
        enemiesLeft.text = enemiesLeftInt.ToString();
    }
}
