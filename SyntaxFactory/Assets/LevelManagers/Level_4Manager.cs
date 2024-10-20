using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class Level_4Manager : MonoBehaviour
{

    public PickupController pickupController;
    public GameObject winPanel; // Reference to a UI panel that shows when the level is won
    public string nextSceneName; // The name of the next scene to load when the level is completed

    private bool levelCompleted = false; // To keep track of whether the level is completed

    void Start()
    {
        pickupController = FindObjectOfType<PickupController>();
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
    private void Update()
    {
  
        if(pickupController.canPickupOrDrop && !levelCompleted)
        {
             levelCompleted = true;
            CompleteLevel();
        }

    }

    // Method to handle level completion
    void CompleteLevel()
    {
      

        // Show the win UI panel


        // Optionally, load the next scene after a delay
        StartCoroutine(LoadNextSceneAfterDelay(2f)); // Delay of 2 seconds
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
}
