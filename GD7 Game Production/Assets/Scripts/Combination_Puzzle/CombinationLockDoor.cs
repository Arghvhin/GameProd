using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLockDoor : MonoBehaviour
{
    public List<ScopesCollisionHandler> scripts = new List<ScopesCollisionHandler>();
    public bool correctCombination;
    public GameObject doorObject; // Public GameObject variable

    // Update is called once per frame
void Update()
{
    correctCombination = true;

    // Iterate through each script
    foreach (ScopesCollisionHandler script in scripts)
    {
        if (!script.isColliding)
        {
            correctCombination = false;
            break; // No need to check further if any script is not colliding
        }
    }

    // Check if all scripts are colliding
    if (correctCombination)
    {
        Debug.Log("Correct combination!");
        if (doorObject != null)
        {
            doorObject.SetActive(false); // Hide the GameObject
        }
    }
    else
    {
        Debug.Log("Incorrect combination.");
        if (doorObject != null)
        {
            doorObject.SetActive(true); // Show the GameObject
        }
    }
}
}
