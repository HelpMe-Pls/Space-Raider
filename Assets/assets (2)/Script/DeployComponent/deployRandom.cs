using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployRandom : MonoBehaviour
{
	public GameObject random1;
	public float respawnTime = 1.0f;
	private Vector2 screenBounds;
	
    // Start is called before the first frame update
    void Start()
    {
		
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(rockWave());
	}
    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void spawnEnemy(){
		int random = Random.Range(0,3);
		if (random == 0){}
		else if (random == 1){
			GameObject a = Instantiate(random1) as GameObject;
			a.transform.position = new Vector2(screenBounds.x * 2, -screenBounds.y);
			a.transform.localScale += new Vector3(0, Random.Range(-4, 2),0);
		}
		else if (random == 2) {
			GameObject a = Instantiate(random1) as GameObject;
			a.transform.position = new Vector2(screenBounds.x * 2, screenBounds.y);
			a.transform.localScale += new Vector3(0, Random.Range(-12, -6),0);
		}
	}
	IEnumerator rockWave(){
		while(true){
			yield return new WaitForSeconds(respawnTime);
			spawnEnemy();
		}
	}
	
	
}
