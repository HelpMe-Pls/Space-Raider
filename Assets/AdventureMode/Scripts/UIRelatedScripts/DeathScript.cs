using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Camera;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerCollisionHandler>().isPlayerDead)
        {
            Canvas.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
