using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPanelController : MonoBehaviour
{
    public List<GameObject> parts;

    public float showDelay=2;

    void Start(){
        HideParts();
        
        Invoke(nameof(ShowParts), showDelay);
    }

    void ShowParts(){
        foreach(var part in parts){
            part.SetActive(true);
        }
    }

    void HideParts(){
        foreach(var part in parts){
            part.SetActive(false);
        }
    }
}
