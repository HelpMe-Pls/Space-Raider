using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	public int moveSpeed;
	
	private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
		if (this.gameObject.transform.position.x < -screenBounds.x * 2) Destroy(this.gameObject);
		
		
		transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, 0 , 0);
    }
	
	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			//add energy 
			//and destroy after add
			Destroy(this.gameObject); 
		}
		
	}
}
