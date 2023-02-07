using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBController : MonoBehaviour
{
    public static void SetLevelIsCompleted(int level, int completed){
        PlayerPrefs.SetInt($"level{level}_is_completed", completed);
    }

    public static int GetLevelIsCompleted(int level){
        return PlayerPrefs.GetInt($"level{level}_is_completed", 0);
    }
}
