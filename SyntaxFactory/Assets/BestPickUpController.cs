using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestPickUpController : MonoBehaviour
{
    public Transform robot; // Reference to the object that's tracking
    public GameObject pickupItem1; // Reference to the pickup item
    public GameObject pickupItem2; // Reference to the pickup item
    public GameObject pickupItem3; // Reference to the pickup item
    public GameObject pickupItem4; // Reference to the pickup item
    public GameObject pickupItem5; // Reference to the pickup item

    public GameObject pickupItem6;

    public GameObject pickedupItem;

    public int currItemIdx;

    public GameObject[] itemArray;

    public float pickupDistance = 1.0f; // Distance threshold for pickup
    public bool canPickupOrDrop = false; // Variable to control pickup/drop functionality

    public bool pickedUp = false;

    private bool isPickedUp = false;

    void Start()
    {
        itemArray = new GameObject[] {pickupItem1, pickupItem2, pickupItem3, pickupItem4, pickupItem5, pickupItem6};
    }

    void Update()
    {
        if (!isPickedUp && robot != null && itemArray[currItemIdx].GetComponent<ArrayProps>().item != null)
        {
            float distance = Vector3.Distance(robot.position, itemArray[currItemIdx].GetComponent<ArrayProps>().item.transform.position);

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
        itemArray[currItemIdx].GetComponent<ArrayProps>().item.transform.parent = robot;

        itemArray[currItemIdx].GetComponent<ArrayProps>().item.transform.localPosition = Vector3.zero; //new
        SpriteRenderer itemRenderer = itemArray[currItemIdx].GetComponent<ArrayProps>().item.GetComponent<SpriteRenderer>();
        SpriteRenderer robotRenderer = robot.GetComponent<SpriteRenderer>();

        if (itemRenderer != null && robotRenderer != null)
        {
            itemRenderer.sortingLayerID = robotRenderer.sortingLayerID;
            itemRenderer.sortingOrder = robotRenderer.sortingOrder + 1; // Ensure item is in front
        }
        
        // Disable the pickup item collider to prevent further interactions
        Collider pickupCollider = itemArray[currItemIdx].GetComponent<ArrayProps>().item.GetComponent<Collider>();
        if (pickupCollider != null)
        {
            pickupCollider.enabled = false;
        }
        
        pickedupItem = itemArray[currItemIdx].GetComponent<ArrayProps>().item;
        isPickedUp = true;
    }
      public void Drop()
    {
        // Example drop action
       // Debug.Log("Item dropped!");

        // Unparent the pickup item from the tracking object
        pickedupItem.transform.parent = itemArray[currItemIdx].transform;
        itemArray[currItemIdx].GetComponent<ArrayProps>().item = pickedupItem;
        pickedupItem = null;
        
        // Enable the pickup item collider to allow further interactions
        Collider pickupCollider = itemArray[currItemIdx].GetComponent<Collider>();
        if (pickupCollider != null)
        {
            pickupCollider.enabled = true;
        }

        isPickedUp = false;
    }
}

