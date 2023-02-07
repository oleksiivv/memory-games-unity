using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : ScenesManager
{
    public GameObject infoPanel;

    public GameObject levelsPanel;

    public LevelsPanel levelsPanelController;

    public void SetInfoPanelActive(bool active=true){
        infoPanel.SetActive(active);
    }

    public void SetLevelsPanelActive(bool active=true){
        levelsPanelController.HideUI();

        if(active){
            levelsPanelController.InvokeShowUI();
        }

        levelsPanel.SetActive(active);
    }
}
