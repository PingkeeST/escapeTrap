using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject LevelCompletedUI;

    public void ComplateLevel() 
    {
        LevelCompletedUI.SetActive(true);
    }
}
