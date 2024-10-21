using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class BestItemManager : MonoBehaviour
{
    public GeneralManager generalManager;

    public GameObject destination; // Reference to the destination GameObject
    private Animator animator;
    public BestPickUpController pickupController;
    public bool isCounting = false; // To track if counting is in progress
    private bool levelCompleted = false; // To keep track of whether the level is completed
    private SpriteRenderer spriteRenderer;
    public int currentLevel;


    void Start()
    {
        pickupController = FindObjectOfType<BestPickUpController>();
        destination =  GameObject.Find("Destino");
        generalManager = FindObjectOfType<GeneralManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
         
        if (!pickupController.canPickupOrDrop && other.gameObject == destination && !levelCompleted)
        {
            if (!isCounting) // Only count if not already counting
            {
             isCounting = true;
             generalManager.IncrementItemCount();
            }

        }

 
            
    }


}
