using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomMove : MonoBehaviour
{
	private Vector2 screenBounds;
	private Rigidbody2D rb;
	
	private int randomChoice;
	private float timeCheck = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		rb = GetComponent<Rigidbody2D>();
		transform.position = new Vector2(screenBounds.x - 2, 0);
		randomChoice = Random.Range(0, 1000);
	}

    // Update is called once per frame
    void Update()
    {
		if (timeCheck > 2){
			randomChoice = Random.Range(0, 1000);
			timeCheck  = 0;
		}
		if (randomChoice <500) transform.position = new Vector2(transform.position.x, transform.position.y + (1)*Time.deltaTime);
		if (randomChoice <1000 && randomChoice >= 500) transform.position = new Vector2(transform.position.x, transform.position.y + (-1)*Time.deltaTime);
        Debug.Log(screenBounds.x + " " + screenBounds.y);
		timeCheck += Time.deltaTime;
		if (transform.position.y >= screenBounds.y - (2) *Time.deltaTime) {
			transform.position = new Vector2(transform.position.x, screenBounds.y - (2.2f) *Time.deltaTime);
			timeCheck = 0;
			randomChoice = 501;
		}
		else if (transform.position.y <= -screenBounds.y + (2) *Time.deltaTime) {
			transform.position = new Vector2(transform.position.x, -screenBounds.y + (2.2f) *Time.deltaTime);
			timeCheck = 0;
			randomChoice = 1;
		}
    }
}
