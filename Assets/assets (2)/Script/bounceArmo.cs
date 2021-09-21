using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceArmo : MonoBehaviour
{
	public int moveSpeed;
	
	private Vector2 screenBounds;
	
	public int hitPoint = 2;
	public int bounceCollision = 0;
	
	private float randomBounce;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		randomBounce = Random.Range(-1.0f,1.0f);
	}

    // Update is called once per frame
    void Update()
    {
		
		if (this.gameObject.transform.position.x < -screenBounds.x * 2) Destroy(this.gameObject);
		
		
		transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime + bounceCollision*randomBounce*Time.deltaTime, 0 + Time.deltaTime * bounceCollision * randomBounce , 0);
    }
	private void OnTriggerEnter2D(Collider2D other){
		//Debug.Log("hit");
		if ((other.gameObject.tag == "armo" || other.gameObject.tag == "player" )&& this.gameObject.tag == "rock" &&hitPoint > 0) {
			hitPoint--;
			bounceCollision = bounceCollision + 1;
		}
		if (hitPoint == 0) Destroy(this.gameObject);
		if (other.gameObject.tag == "armo") Destroy(other.gameObject);
		
		if (other.gameObject.tag == "StrongArmor") Destroy(this.gameObject);
		
	}
}
