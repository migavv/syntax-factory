using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class Level_2Manager : MonoBehaviour
{
    public GameObject destination; // Reference to the destination GameObject
    public GameObject destination2; // Second destination GameObject
      private bool visitedDestination = false; // To track if destination1 has been visited
    private bool visitedDestination2 = false; // To track if destination2 has been visited
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
         // Check if the player entered destination1 or destination2
        if (other.gameObject == destination && !visitedDestination)
        {
            visitedDestination = true;
            //Debug.Log("Visited Destination 1");
        }

         if (other.gameObject == destination2 && !visitedDestination2)
        {
            visitedDestination2 = true;
           // Debug.Log("Visited Destination 2");
        }

         if (visitedDestination && visitedDestination2 && !levelCompleted)
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
