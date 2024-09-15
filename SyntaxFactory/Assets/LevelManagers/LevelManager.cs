using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class LevelManager : MonoBehaviour
{
    public GameObject destination; // Reference to the destination GameObject
    public GameObject winPanel; // Reference to a UI panel that shows when the level is won
    public string nextSceneName; // The name of the next scene to load when the level is completed

    private bool levelCompleted = false; // To keep track of whether the level is completed

    void Start()
    {
      
        // Ensure the winPanel is not active at the start
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Win Panel is not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // Check if the player has entered the destination's trigger zone
        if (other.gameObject == destination && !levelCompleted)
        {
              
            levelCompleted = true;
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
