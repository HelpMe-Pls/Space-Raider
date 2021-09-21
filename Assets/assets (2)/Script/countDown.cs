using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countDown : MonoBehaviour
{
    // Start is called before the first frame update
	public float countScd = 4.0f;
    void Start()
    {
		StartCoroutine(countDwn());
    }

    IEnumerator countDwn(){
		while(true){
			yield return new WaitForSeconds(countScd);
			Destroy(gameObject);
		}
	}
}
