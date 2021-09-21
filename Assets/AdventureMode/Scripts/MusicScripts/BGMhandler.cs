using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMhandler : MonoBehaviour
{
    AudioSource stageTheme;
    
    void Start()
    {
        
    }

    void Update()
    {
        stageTheme = GetComponent<AudioSource>();
        bool isPaused = GameObject.Find("PauseMenu").GetComponent<PauseMenu>().GameIsPaused;
        if (isPaused) stageTheme.Pause();
        else if (!isPaused) stageTheme.UnPause();

        bool isDead = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionHandler>().isPlayerDead;
        if (isDead) stageTheme.Stop();

        bool isLevelCleared = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionHandler>().isLevelCleared;
        if (isLevelCleared) stageTheme.Stop();
    }
}
