using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployComponent : MonoBehaviour
{
	public GameObject Rock;
	public float respawnTime = 1.0f;
	public float timespawn = 15;
	
	private Vector2 screenBounds;
	
	private float countTime = 0.0f;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		
		StartCoroutine(rockWave());

	}
    // Update is called once per frame
    void Update()
    {
        countTime = countTime + Time.deltaTime;

    }
	// spawn Enemy
	private void spawnEnemy(){
		int check = (int)(countTime / timespawn) + 1;
		for (int z = 0 ; z < check ; z++ ) {
			GameObject a = Instantiate(Rock) as GameObject;
			a.transform.position = new Vector2(screenBounds.x * 2 + z*2 , Random.Range(-screenBounds.y + 0.1f, screenBounds.y));
		}
	}
	IEnumerator rockWave(){
		while(true){
			yield return new WaitForSeconds(respawnTime);
			spawnEnemy();
		}
	}

}
