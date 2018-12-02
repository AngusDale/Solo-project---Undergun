using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //Blackthorne prod transition tutorial.
    public Animator transAnimation;
    public string gameScene;
    public string menuScene;
    public GameObject gameOver;

    public void Menu()
    {
        StartCoroutine(MenuLoad());
    }

    public void StartGame()
    {
        StartCoroutine(StartLoad());
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
        SceneManager.LoadScene(menuScene);
    }

    IEnumerator MenuLoad()
    {
        transAnimation.SetTrigger("end");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(menuScene);
    }
}
