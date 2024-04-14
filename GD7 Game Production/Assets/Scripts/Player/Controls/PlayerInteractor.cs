using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField]
    PlayerInventory inventory;
    [SerializeField]
    Text interactionText;
    [SerializeField]
    Transform cameraPosition;


    [SerializeField]
    float raycastDistance = 2f;


    IInteractible selectedInteractible;
    


    void Start()
    {
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
            if (selectedInteractible != null) {
                selectedInteractible.Interact("interact");
                
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
                interactionText.text = selectedInteractible.GetDisplayText();

                Debug.Log(selectedInteractible.GetDisplayText());
            }

        }
        else
        {
            selectedInteractible = null;
            interactionText.text = "";
        }
        Debug.DrawRay(cameraPosition.position, cameraPosition.forward * raycastDistance, Color.red);
    }

    public IInteractible GetInteractible() {
        return selectedInteractible;
    }
}





