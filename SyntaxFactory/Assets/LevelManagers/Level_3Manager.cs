using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class Level_3Manager : MonoBehaviour
{
    public GameObject destination; // Reference to the destination GameObject
    public GameObject destination2; // Second destination GameObject
      private int visitedDestination = 0; // To track if destination1 has been visited
    private int visitedDestination2 = 0; // To track if destination2 has been visited
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
        if (other.gameObject == destination)
        {
            visitedDestination +=1;
            //Debug.Log("Visited Destination 1");
        }

         if (other.gameObject == destination2)
        {
            visitedDestination2 +=1;
           // Debug.Log("Visited Destination 2");
        }

         if (visitedDestination == 5 && visitedDestination2 == 5 && !levelCompleted)
        {
            levelCompleted = true;
            CompleteLevel();
        }
    }

    // Method to handle level completion
    void CompleteLevel()
    {
      
        // Optionally, load the next scene after a delay
        StartCoroutine(LoadNextSceneAfterDelay(2f)); // Delay of 2 seconds
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        // Show the win UI panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
}
