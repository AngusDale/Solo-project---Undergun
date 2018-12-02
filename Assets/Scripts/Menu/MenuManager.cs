using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    //Blackthorne prod transition tutorial.
    public Animator transAnimation;
    public string gameScene;
    public string menuScene;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject player;

    public void Menu()
    {
        StartCoroutine(MenuLoad());
    }

    public void StartGame()
    {
        StartCoroutine(StartLoad());
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void YouWon()
    {
        PlayerController PC = player.GetComponent<PlayerController>();
        PC.canMove = false;
        youWon.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        print("QUIT");
    }

    IEnumerator StartLoad()
    {
        transAnimation.SetTrigger("end");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(gameScene);
    }

    IEnumerator MenuLoad()
    {
        transAnimation.SetTrigger("end");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(menuScene);
    }    
}
