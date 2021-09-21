using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Camera;
    public bool Paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Time.timeScale = 1f;
                Canvas.gameObject.SetActive(false);
                //Camera.audio.Play();
                Paused = false;
            }
            else
            {
                Time.timeScale = 0f;
                Canvas.gameObject.SetActive(true);
                //Camera.audio.Pause();
                Paused = true;
            }
        }
    }
}
