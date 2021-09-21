using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSkill_play : MonoBehaviour
{
    // Start is called before the first frame update
	Transform bossPos;
	
	public GameObject deployFireBall;
	
	private Vector2 screenBounds;
	
	//private float countTime = 0.0f;
	
	
	
    // Start is called before the first frame update

    void Start()
    {
        bossPos = GameObject.FindGameObjectWithTag("Enemy").transform;
		transform.position = bossPos.position;
		
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		
		StartCoroutine(fireBallWave());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = bossPos.position;
    }
	private void spawnFireBall(){
		GameObject a = Instantiate(deployFireBall) as GameObject;
		a.transform.position = new Vector2(Random.Range(-screenBounds.x * 2, 0) ,screenBounds.y + 3);
		
	}
	IEnumerator fireBallWave(){
		while(true){
			yield return new WaitForSeconds(0.3f);
			spawnFireBall();
		}
	}
}
