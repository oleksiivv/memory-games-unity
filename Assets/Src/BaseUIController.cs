using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIController : ScenesManager
{
    public GameObject pausePanel, gameOverPanel, winPanel;

    public ParticleSystem winEffect, gameOverEffect;

    public void OpenScene(int n){
        OpenSceneAsync(n);
    }

    public void Next(bool IsLast){
        if(IsLast){
            OpenScene(0);
            return;
        }

        OpenScene(Application.loadedLevel+1);
    }

    public void Pause(){
        Time.timeScale = 0;

        pausePanel.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;

        pausePanel.SetActive(false);
    }

    public void Restart(){
        Time.timeScale = 1;

        OpenSceneAsync(Application.loadedLevel);
    }

    public void Lose(){
        //gameOverEffect.Play();
        gameOverPanel.SetActive(true);
    }

    public void Win(){
        winPanel.SetActive(true);
        //winEffect.Play();
    }
}
