using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameScript : MonoBehaviour
{
    public void MainMenuPage () {
        // two ways to load a scene. with 
        SceneManager.LoadScene("MainMenu");
        // or by build index through build settings
        // SceneManager.LoadScene(GetActiveScene.buildIndex - 1);
    }
    // public void OptionMenu () {
    // }
}
