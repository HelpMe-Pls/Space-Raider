using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
	public GameObject checkShowLose;
	public GameObject settingMenuUI;
	public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) && !(checkShowLose.activeSelf)){
			if (GameIsPaused)
			{
				Resume();
			}
			else {
				Pause();
			}
		}
    }
	
	public void Resume(){
		pauseMenuUI.SetActive(false);
		settingMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		
	}
	
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		
	}
	
	public void QuitGame(){
		Application.Quit();
		
	}
	
	public void loadMainMenu(){
		//Debug.Log("loading menu");
		SceneManager.LoadScene("Scenes/StartMenu");
	}
}
