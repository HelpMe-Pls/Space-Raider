using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndHit : MonoBehaviour
{
	//public GameObject Target;
	Transform player;
	public float waitingTime = 2.0f;
	public GameObject destroyEffect; //effect khi bi pha hong
	
	
	private float realTime;
	private bool checkActive = false;
    // Start is called before the first frame update
    void Start()
    {
        realTime = 0;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
    }

    // Update is called once per frame
    void Update()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        if (realTime <= 1) {
			realTime += Time.deltaTime;
			transform.position = player.position;
		}
		if (realTime > 1 && checkActive == false) {
			Debug.Log("Active");
			checkActive = true;
			StartCoroutine(activeSkill());
		}
    }
	
	void Hit(){
		
	}

	
	//tạo ra ham cho dan song den khi bi pha huy -> armo range
	
	IEnumerator activeSkill(){
		while(true){
			yield return new WaitForSeconds(waitingTime);
			Hit();
			Invoke("DestroyProjectile", 0f);

		}
	}
		void DestroyProjectile(){
		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
