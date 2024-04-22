using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class UnlockableObject : MonoBehaviour
{
    public bool isUnlocked = false; // Public variable to indicate if the object is unlocked
    private CapsuleCollider capsuleCollider; // Reference to the CapsuleCollider component
    private Rigidbody rb; // Reference to the Rigidbody component

    // Reference to the scripts whose boolean value needs to be set
    public MonoBehaviour[] scriptsToSetTrue;
    void Start()
    {
        // Get the CapsuleCollider and Rigidbody components attached to the game object
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        
        // Disable the capsule collider and gravity initially
        capsuleCollider.enabled = false;
        rb.useGravity = false;
    }

    void Update()
    {
        // Check if the object is unlocked
        if (isUnlocked)
        {
            // Enable the capsule collider and gravity
            capsuleCollider.enabled = true;
            rb.useGravity = true;
                    // Loop through each assigned script and set its boolean value to true
        foreach (MonoBehaviour script in scriptsToSetTrue)
        {
            if (script != null)
            {
                // Check if the script has a boolean variable named "isRotating"
                var isRotatingField = script.GetType().GetField("isRotating");
                if (isRotatingField != null && isRotatingField.FieldType == typeof(bool))
                {
                    // Set the boolean value to true
                    isRotatingField.SetValue(script, true);
                }
                else
                {
                    Debug.LogError("Script does not have a boolean variable named 'isRotating'.");
                }
            }
            else
            {
                Debug.LogError("Assigned script is null.");
            }
        }
    }
        }
    
}