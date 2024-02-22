using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFrameController : MonoBehaviour
{
    public string playerTag = "Player";
    public string pickableTag = "Pickable";
    public float detectionRadius = 10f;
    public bool isNearPlayer;
    public bool isFacingPickable;

    public Camera mainCamera; // Reference to the camera

    void Update()
    {
        // Find the game object with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null && mainCamera != null)
        {
            // Find all game objects with the "Pickable" tag
            GameObject[] pickables = GameObject.FindGameObjectsWithTag(pickableTag);

            // Set the initial state
            isNearPlayer = false;
            isFacingPickable = false;

            foreach (GameObject pickable in pickables)
            {
                // Calculate distance between player and pickable object
                float distance = Vector3.Distance(player.transform.position, pickable.transform.position);

                // Check if the pickable object is within the detection radius
                if (distance <= detectionRadius)
                {
                    // Output that the pickable is near the player
                    Debug.Log("Pickable is near the player!");
                    isNearPlayer = true;

                    // Check if the camera is facing the pickable object
                    Vector3 cameraToPickable = pickable.transform.position - mainCamera.transform.position;
                    cameraToPickable.Normalize();
                    float dotProduct = Vector3.Dot(mainCamera.transform.forward, cameraToPickable);

                    if (dotProduct > 0.5f) // You can adjust the threshold as needed
                    {
                        // Output that the camera is facing the pickable object
                        Debug.Log("Camera is facing the pickable!");
                        isFacingPickable = true;
                    }
                }
            }

            // If no pickable is near the player, set the state accordingly
            if (!isNearPlayer)
            {
                Debug.Log("Not near the player!");
            }

            // If no pickable is facing the camera, set the state accordingly
            if (!isFacingPickable)
            {
                Debug.Log("Camera is not facing the pickable!");
            }
        }
    }
}
