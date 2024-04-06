using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Transform robot; // Reference to the object that's tracking
    public Transform pickupItem; // Reference to the pickup item
    public float pickupDistance = 1.0f; // Distance threshold for pickup

    private bool isPickedUp = false;

    void Update()
    {
        if (!isPickedUp && robot != null && pickupItem != null)
        {
            float distance = Vector3.Distance(robot.position, pickupItem.position);

            // Check if the tracking object is close enough to the pickup item for pickup
            if (distance <= pickupDistance)
            {
                // Perform pickup action
                Pickup();
            }
        }
    }

    void Pickup()
    {
        // Example pickup action
        Debug.Log("Item picked up!");
        
        // Parent the pickup item to the tracking object
        pickupItem.parent = robot;
        
        // Disable the pickup item collider to prevent further interactions
        Collider pickupCollider = pickupItem.GetComponent<Collider>();
        if (pickupCollider != null)
        {
            pickupCollider.enabled = false;
        }
        
        isPickedUp = true;
    }
}
