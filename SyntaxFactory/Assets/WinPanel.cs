using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class WinPanel : MonoBehaviour
{
   public string nextSceneName;
   public string menu;
   public string levelSelector;

   public void MainMenu(){
        
        SceneManager.LoadScene(menu);

    }

    public void LevelSelector(){
        
        SceneManager.LoadScene(levelSelector);
        
    }

   public void LoadLevel(){
        SceneManager.LoadScene(nextSceneName);
    }
    
}
