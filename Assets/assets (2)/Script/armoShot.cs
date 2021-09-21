using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armoShot : MonoBehaviour
{
    
	public float speed;
	public float lifeTime; //thoi gian ton tai cua dan
	
	public GameObject destroyEffect; //effect khi dan bi pha hong
	
	private void Start(){
		
		Invoke("DestroyProjectile", lifeTime);
	}
	
	private void Update(){
		
		transform.Translate(Vector2.up * speed * Time.deltaTime);
		
	}
	//tạo ra ham cho dan song den khi bi pha huy -> armo range
	void DestroyProjectile(){
		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);

		
	}
	
}
