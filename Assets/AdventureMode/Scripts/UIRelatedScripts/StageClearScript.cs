using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearScript : MonoBehaviour
{
    public GameObject StageClearUI;
    public GameObject player;
    public string nextLevel;

    void Update()
    {
        if (player.GetComponent<PlayerCollisionHandler>().isLevelCleared)
        {
            StageClearUI.gameObject.SetActive(true);
            if (Input.GetKey("escape"))
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
