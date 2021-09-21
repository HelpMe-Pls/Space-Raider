using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject Coin;
	public float respawnTime = 1.0f;
	private Vector2 screenBounds;
	
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		
		StartCoroutine(coinWave());

	}
    // Update is called once per frame
    void Update()
    {
        
    }
	// spawn Enemy
	private void spawnCoin(){
		GameObject a = Instantiate(Coin) as GameObject;
		a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
	}
	IEnumerator coinWave(){
		while(true){
			yield return new WaitForSeconds(respawnTime + 1.0f);
			spawnCoin();
		}
	}
}
