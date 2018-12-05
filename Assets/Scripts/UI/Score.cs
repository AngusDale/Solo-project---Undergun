using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    /* this script keeps track of the player's score. The score is calculated by the amount of points each enemy gives added together multiplied
     * by the amount of health the player has. I am using a lot of GetComponents in this script in order to access things like, the player's health
     * enemy points value, as well as the menu so that it will display the correct along with score. */

    public Text score;
    public Text highScore;
    public Text screenScore;
    int highScoreNum;
    int scoreNum;
    int health;

    public GameObject player;
    public GameObject spawner;
    public GameObject Menu;
    

    public int killCount = 0;
    public int killScore = 0;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    private void Update()
    {
        PlayerEffects PE = player.GetComponent<PlayerEffects>();
        Spawner spawn = spawner.GetComponent<Spawner>();
        health = PE.playerHealth;

        scoreNum = killScore * health;

        screenScore.text = scoreNum.ToString();

        //This will call the GameWon function which calls the YouWon function inside the MenuManager script 
        //displays the YouWon game object when the game is won.

        if (killCount >= spawn.waveSize)
        {
            //print("GAME WON SCORENUM: " + scoreNum);
            GameWon();
        }
    }

    void GameWon()
    {
        MenuManager MM = Menu.GetComponent<MenuManager>();                
        MM.YouWon();
        ChangeText();
    }

    public void ChangeText()
    {        
        score.text = scoreNum.ToString();
        if (PlayerPrefs.GetInt("Highscore", 0) < scoreNum)
        {
            PlayerPrefs.SetInt("Highscore", scoreNum);
            highScore.text = scoreNum.ToString();
        }   
    }
}
