using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopesCollisionHandler : MonoBehaviour
{
    // Public variable to hold the reference to the object to detect collisions with
    public GameObject targetObject;
    
    // Public variable to track if the GameObject is currently colliding
    public bool isColliding;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object matches the specified targetObject
        if (collision.gameObject == targetObject)
        {
            Debug.Log("Colliding with " + targetObject.name);
            isColliding = true;
            // Do something when colliding with the targetObject
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the previously collided object matches the specified targetObject
        if (collision.gameObject == targetObject)
        {
            Debug.Log("No longer colliding with " + targetObject.name);
            isColliding = false;
            // Do something when no longer colliding with the targetObject
        }
    }
}
