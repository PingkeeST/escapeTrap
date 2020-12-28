using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void Play () {
        // two ways to load a scene. with 
        SceneManager.LoadScene("controllers");
        // or by build index through build settings
        // SceneManager.LoadScene(GetActiveScene.buildIndex + 1);
    }
    public void QuitGame () {
        Application.Quit();
    }

}
