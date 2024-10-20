using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public string nextSceneName; // The name of the next scene to load when the level is completed

    public void PlayGame(){
        SceneManager.LoadScene(nextSceneName);
    }
    public void QuitGame(){
        Application.Quit();
    }
    
}
