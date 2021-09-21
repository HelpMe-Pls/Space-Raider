using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithFade : MonoBehaviour
{
    public GameObject loadScene;
	public Animator transition;
	public float waitTime = 1f;
	
	void Start(){
		loadScene.SetActive(true);
		LoadScene();
	}

    // Update is called once per frame
    void Update(){
		if ((Input.GetKeyDown(KeyCode.Space)))
			SceneManager.LoadScene("Scenes/MainGame");
	}
	
	public void LoadScene(){
		StartCoroutine(LoadSceneNext());
	}
	
	
	IEnumerator LoadSceneNext(){
		//Play animation
		transition.SetTrigger("Start");
		//wait
		yield return new WaitForSeconds(waitTime);
		//load scene
		
		
	}
}
