using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    public List<GameObject> levels;

    public List<GameObject> padlocks;

    public MenuController menu;

    void Start(){
        padlocks[0].SetActive(false);

        for(int i=2; i<=levels.Count; i++){
            Debug.Log(DBController.GetLevelIsCompleted(i-1) == 1);
            padlocks[i-1].SetActive(DBController.GetLevelIsCompleted(i-1) != 1);
        }
    }

    public void StartLevel(int n){
        if(n == 1 || DBController.GetLevelIsCompleted(n-1) == 1){
            menu.OpenSceneAsync(n);
        }
    }
}
