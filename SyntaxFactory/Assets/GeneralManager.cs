using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class GeneralManager : MonoBehaviour
{

    public int itemCount = 0;
    public int winCondition = 3;
    public GameObject winPanel; // Reference to a UI panel that shows when the level is won
    public string nextSceneName; // The name of the next scene to load when the level is completed

     public void IncrementItemCount()
    {
        itemCount++;
        if(itemCount >= winCondition){
            CompleteLevel();
        }
        
    }

    // Method to handle level completion
    void CompleteLevel()
    {
      

        // Show the win UI panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Optionally, load the next scene after a delay
        StartCoroutine(LoadNextSceneAfterDelay(2f)); // Delay of 2 seconds
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }

}
