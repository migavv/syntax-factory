using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class ItemManager : MonoBehaviour
{
    public GeneralManager generalManager;

    public GameObject destination; // Reference to the destination GameObject
    public GameObject itemPrefab; // Prefab of the item to spawn
    public Transform spawnLocation; // Where the new items should spawn
    private Animator animator;
    public int totalItemsToDeliver = 3; // Total items needed for the win condition
    public float spawnDelay = 0.8f; // Delay before the next item spawns
    public PickupController pickupController;
    public string nextSceneName; // The name of the next scene to load when the level is completed
    public bool isCounting = false; // To track if counting is in progress
    private bool levelCompleted = false; // To keep track of whether the level is completed
    public bool isTrash =false;
    public Sprite trashSprite; // Assign this in the Inspector to the trash sprite
    public Sprite regularSprite; // Assign this to the regular sprite
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        pickupController = FindObjectOfType<PickupController>();
        destination =  GameObject.Find("Destino");
        spawnLocation = GameObject.Find("Destino2").transform;
        generalManager = FindObjectOfType<GeneralManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(PlayAnimationWithDelay(0.7f));
        if (currentLevel >6){
            isTrash = Random.value > 0.7f; // 70% chance for true or false
        }
        


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
        animator.SetBool("Delivered", true);
        yield return new WaitForSeconds(spawnDelay);

        // Spawn a new item at the specified spawn location
        GameObject newItem = Instantiate(itemPrefab, spawnLocation.position, spawnLocation.rotation);
        pickupController.pickupItem = newItem.transform;
        Destroy(gameObject);
    }

     IEnumerator PlayAnimationWithDelay(float delay)
    {
        // Wait for the specified number of seconds
        yield return new WaitForSeconds(delay);

        // Play the animation
  
        animator.SetBool("Spawned", false);

        if (isTrash){
            animator.SetBool("isTrash",true);
        }else{
            animator.SetBool("isTrash", false);
        }
        
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
