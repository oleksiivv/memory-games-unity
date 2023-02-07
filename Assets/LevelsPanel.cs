using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPanel : MonoBehaviour
{
    public List<GameObject> ui;

    public float delay = 2f;

    public void HideUI(){
        foreach(var uiPart in ui){
            uiPart.SetActive(false);
        }
    }

    public void InvokeShowUI(){
        CancelInvoke(nameof(ShowUI));
        Invoke(nameof(ShowUI), delay);
    }

    private void ShowUI(){
        foreach(var uiPart in ui){
            uiPart.SetActive(true);
        }
    }
}
