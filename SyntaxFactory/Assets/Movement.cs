using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
public class Movement : MonoBehaviour
{
   public Transform blueTarget;
    public Transform whiteTarget;
    public Button blueButton;
    
    public Button whiteButton; // Reference to the button to activate A* pathfinding

    public Transform currentTarget; // Reference to the target object
    public float stoppingDistance = 1.5f; // Distance threshold to stop at
    
    private AIPath aiPath; // Reference to the A* pathfinding script

    private AIDestinationSetter destinationSetter;

    void Start()
    {

        
        aiPath = GetComponent<AIPath>(); // Get reference to the A* pathfinding script
        aiPath.enabled = false;
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.enabled = false; // Disable the AIDestinationSetter initially

        whiteButton.onClick.AddListener(() => SetTarget(whiteTarget));
        blueButton.onClick.AddListener(() => SetTarget(blueTarget));
        
    }

    void Update()
    {
        if (currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
            Debug.Log("Distance to target: " + distanceToTarget);
            // If the object is close enough to the target, stop its movement
            if (distanceToTarget <= stoppingDistance)
            {
                
                aiPath.enabled = false; // Disable A* pathfinding
                // Optionally, you can stop the object's movement completely
                // by setting its velocity to zero if it has a Rigidbody component
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }
    // Method to activate A* pathfinding
   void SetTarget(Transform target)
    {
        Debug.Log("Button clicked! Setting target to: " + target.name);
        currentTarget = target;

        // Enable the AIDestinationSetter component
        destinationSetter.enabled = true;
        
        // Set the new target for the AIDestinationSetter
        destinationSetter.target = target;
        
       aiPath.enabled = true;
    }

}
