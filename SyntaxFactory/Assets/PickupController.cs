using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Transform robot; // Reference to the object that's tracking
    public GameObject pickupItem; // Reference to the pickup item
    public float pickupDistance = 1.0f; // Distance threshold for pickup
    public bool canPickupOrDrop = false; // Variable to control pickup/drop functionality

    public bool pickedUp = false;

    private bool isPickedUp = false;

    void Update()
    {
        if (!isPickedUp && robot != null && pickupItem != null)
        {
            float distance = Vector3.Distance(robot.position, pickupItem.transform.position);

            // Check if the tracking object is close enough to the pickup item for pickup
            if (canPickupOrDrop && distance <= pickupDistance)
            {
                Debug.Log(canPickupOrDrop);
                // Perform pickup action
                Pickup();
            }
        }
    }

    void Pickup()
    {
        // Example pickup action
        //Debug.Log("Item picked up!");
        
        // Parent the pickup item to the tracking object
        pickupItem.transform.parent = robot;

        pickupItem.transform.localPosition = Vector3.zero; //new
        SpriteRenderer itemRenderer = pickupItem.GetComponent<SpriteRenderer>();
        SpriteRenderer robotRenderer = robot.GetComponent<SpriteRenderer>();
            if (itemRenderer != null && robotRenderer != null)
        {
            itemRenderer.sortingLayerID = robotRenderer.sortingLayerID;
            itemRenderer.sortingOrder = robotRenderer.sortingOrder + 1; // Ensure item is in front
        }
        
        // Disable the pickup item collider to prevent further interactions
        Collider pickupCollider = pickupItem.GetComponent<Collider>();
        if (pickupCollider != null)
        {
            pickupCollider.enabled = false;
        }
        
        isPickedUp = true;
    }
      public void Drop()
    {
        // Example drop action
       // Debug.Log("Item dropped!");

        // Unparent the pickup item from the tracking object
        pickupItem.transform.parent = null;
        
        // Enable the pickup item collider to allow further interactions
        Collider pickupCollider = pickupItem.GetComponent<Collider>();
        if (pickupCollider != null)
        {
            pickupCollider.enabled = true;
        }

        isPickedUp = false;
    }
}
