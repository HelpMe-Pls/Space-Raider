using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollweapon : MonoBehaviour
{
	public float offset;
    
	public GameObject projectile; //dua sprite armo
	public Transform shotPoint; //dua object shotPoint vao
	public GameObject checkMenuOn;
	
	// Start is called before the first frame update
	
    private void Update(){
		
		transform.rotation = Quaternion.Euler(0f, 0f, 0);
		
		
		
		
		
		if (Input.GetMouseButtonDown(0) && !(checkMenuOn.activeSelf)) {
			Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, offset)); //tự động tạo ra 1 object clone của đạn
		}
	}
}
