using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRender : MonoBehaviour
{
	//private Vector2 screenBounds;
	private Camera cam; 
    // Start is called before the first frame update
    void Start()
    {
		cam = Camera.main;
		//Debug.Log(camera);
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
		Debug.Log(height + " " + width);
		//screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(screenBounds.transform.localScale);
    }
}
