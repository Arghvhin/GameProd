using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDrawers : MonoBehaviour
{
    public GameObject drawer; // Public reference to the drawer GameObject
    public float speed = 5.0f; // Public speed for movement (adjustable)
    public float offset = 1.0f; // Public offset for movement relative to initial position
    public bool open = false; // Flag to control whether the drawer is open or closed

    private Vector3 initialPosition; // Private variable to store the initial position of the drawer
    private Vector3 targetPosition; // Private variable to store the target position of the drawer

    // Start is called before the first frame update
    void Start()
    {
        // Ensure drawer reference is assigned in the Inspector
        if (drawer == null)
        {
            Debug.LogError("Please assign the drawer GameObject in the Inspector!");
        }

        // Store the initial position of the drawer
        initialPosition = drawer.transform.position;

        // Calculate the target position based on the offset
        targetPosition = initialPosition + new Vector3(offset, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            MoveDrawer(targetPosition);
        }
        else
        {
            MoveDrawer(initialPosition);
        }
    }

    // Move the drawer to the specified target position
    void MoveDrawer(Vector3 targetPosition)
    {
        Vector3 currentPosition = drawer.transform.position;

        // Calculate movement towards the target position
        Vector3 movement = (targetPosition - currentPosition).normalized * speed * Time.deltaTime;

        // Update position smoothly
        drawer.transform.position += movement;

        // Constrain movement within specified limits
        float minX = Mathf.Min(currentPosition.x, targetPosition.x);
        float maxX = Mathf.Max(currentPosition.x, targetPosition.x);
        currentPosition.x = Mathf.Clamp(drawer.transform.position.x, minX, maxX);

        // Update position while considering constraints
        drawer.transform.position = currentPosition;
    }
}
