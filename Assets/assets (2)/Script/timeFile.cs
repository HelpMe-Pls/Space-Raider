using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeFile : MonoBehaviour
{
	public Text timeText;
	
	private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = 0 + "";
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
		
		timeText.text = (int)time + "";
    }
}
