using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinish : MonoBehaviour
{
	public GameObject finish;
	
	private Rigidbody2D rb;
	private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if ( rb.position.y <= -screenBounds.y) {
			finish.SetActive(true);
			Time.timeScale = 0f;
			if (Input.GetKey(KeyCode.R)){
				
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				Time.timeScale = 1f;
			}

			
		}
    }
	
	public void Replay(){
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
	}
}
