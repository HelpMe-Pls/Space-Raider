using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllers : MonoBehaviour
{
    public Animator transition;
    public GameObject loadCanvas;

    public float waitTime = 1f;
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void playSurvival()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void playCampaign()
    {
        SceneManager.LoadScene("SideScroller_Level01");
    }

    public void help()
    {
        SceneManager.LoadScene("WaitingScene");
    }

    /*public void setting()
    {
        activated by Unity UIE
    }*/

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}