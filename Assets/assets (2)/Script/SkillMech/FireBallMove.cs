using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
	public float Speed;
	
	private Vector2 screenBounds;

	
	void Start(){
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}
	
	void Update(){
		transform.position = transform.position + new Vector3(Speed * Time.deltaTime,-Speed * Time.deltaTime  , 0);

		if (transform.position.x > screenBounds.x && transform.position.y < -screenBounds.y)
			Destroy(gameObject);

	}
	

	
	
}
