using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer_BloodMech : MonoBehaviour
{
	Transform bossPos;
	Transform player;
	public float speed;
	
	private bool delayFinish = false;
	private Vector2 screenBounds;
	
    // Start is called before the first frame update
    void Start()
    {
        bossPos = GameObject.FindGameObjectWithTag("Enemy").transform;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = new Vector3(bossPos.position.x - 100*Time.fixedDeltaTime, player.position.y, 0);
		StartCoroutine(delayForAnimation());
		
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

	}

    // Update is called once per frame
    void Update()
    {
		if (delayFinish == true)
			transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0 , 0);
    
		if (transform.position.x < -screenBounds.x - 2)
			Destroy(gameObject);

	}
	IEnumerator delayForAnimation(){
		while(true){
			yield return new WaitForSeconds(0.3f);
			delayFinish = true;
			
		}
	}
}
