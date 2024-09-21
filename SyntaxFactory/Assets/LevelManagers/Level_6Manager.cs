using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class Level_6Manager : MonoBehaviour
{
    public GeneralManager generalManager;

    public GameObject destination; // Reference to the destination GameObject
    public GameObject itemPrefab; // Prefab of the item to spawn
    public Transform spawnLocation; // Where the new items should spawn
    public int totalItemsToDeliver = 3; // Total items needed for the win condition
    public float spawnDelay = 0.5f; // Delay before the next item spawns
    public PickupController pickupController;
    public string nextSceneName; // The name of the next scene to load when the level is completed
    public bool isCounting = false; // To track if counting is in progress


    private bool levelCompleted = false; // To keep track of whether the level is completed

    void Start()
    {
        pickupController = FindObjectOfType<PickupController>();
        destination =  GameObject.Find("Destino");
        spawnLocation = GameObject.Find("Destino2").transform;
        generalManager = FindObjectOfType<GeneralManager>();

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        // Check if the player has entered the destination's trigger zone
        
        if (!pickupController.canPickupOrDrop && other.gameObject == destination && !levelCompleted)
        {
            if (!isCounting) // Only count if not already counting
            {
             StartCoroutine(CountItemAfterDelay());
            }
            StartCoroutine(SpawnNewItemAfterDelay());

        }

 
            // Destroy the delivered item
            
    }

    private IEnumerator SpawnNewItemAfterDelay()
    {
        //Debug.Log("Item spawned");
        yield return new WaitForSeconds(spawnDelay);

        // Spawn a new item at the specified spawn location
        GameObject newItem = Instantiate(itemPrefab, spawnLocation.position, spawnLocation.rotation);
        pickupController.pickupItem = newItem.transform;
        Destroy(gameObject);
    }
    private IEnumerator CountItemAfterDelay()
{
    isCounting = true; // Set counting to true
    
    generalManager.IncrementItemCount();

    // Wait for the specified delay
    yield return new WaitForSeconds(spawnDelay);

    isCounting = false; // Reset counting to allow for future counts
}

}