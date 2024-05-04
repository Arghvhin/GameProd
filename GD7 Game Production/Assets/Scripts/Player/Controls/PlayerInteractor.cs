using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{

    [SerializeField]
    PlayerInventory inventory;

    InteractionText interactionText;
    [SerializeField]
    Transform cameraPosition;


    [SerializeField]
    float raycastDistance = 2f;

    IInteractible selectedInteractible;
    


    void Start()
    {
        inventory = FindObjectOfType<PlayerInventory>();
        interactionText = FindObjectOfType<InteractionText>();
    }

    private void Update()
    {
        Inputs();
        CheckInteractible();

    }

    private void FixedUpdate()
    {
    }

    private void Inputs()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (selectedInteractible != null)
            {
                selectedInteractible.Interact(inventory.GetKey());
            }
                
            
        }
    }

    private void CheckInteractible() {
        RaycastHit hit;
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, raycastDistance))
        {
            Debug.Log(hit);
            IInteractible checkedObject = hit.collider.GetComponent<IInteractible>();
            if (checkedObject != null)
            {
                selectedInteractible = checkedObject;
                interactionText.SetText(selectedInteractible.GetDisplayText(inventory.GetKey()));

                Debug.Log(selectedInteractible.GetDisplayText(inventory.GetKey()));
            }

        }
        else
        {
            selectedInteractible = null;
            interactionText.SetText("");
        }
        Debug.DrawRay(cameraPosition.position, cameraPosition.forward * raycastDistance, Color.red);
    }

    public IInteractible GetInteractible() {
        return selectedInteractible;
    }
}





