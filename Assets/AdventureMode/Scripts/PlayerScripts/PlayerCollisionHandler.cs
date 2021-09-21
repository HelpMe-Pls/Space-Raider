using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    public int bulletPower = 1;
    public bool isPlayerDead;
    public bool isLevelCleared;

    void Start()
    {
        Time.timeScale = 1f;
        isPlayerDead = false;
        isLevelCleared = false;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown("escape") && isPlayerDead)
    //    {
    //        SceneManager.LoadScene("SideScroller_Level01");
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy" || col.transform.tag == "rock")
        {
            Die();
        }
        else if (col.transform.tag == "Finish")
        {
            StageClear();
        }
    }
    void Die()
    {
        Time.timeScale = 0f;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isPlayerDead = true;
        GameObject.Find("PauseMenu").GetComponent<PauseMenu>().enabled = false;
    }

    void StageClear()
    {
        Time.timeScale = 0f;
        GameObject.Find("PauseMenu").GetComponent<PauseMenu>().enabled = false;
        isLevelCleared = true;
    }

    //void OnGUI()
    //{
    //    if (isPlayerDead)
    //    {
    //        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "Game Over");
    //    }
    //}
}
