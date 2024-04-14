using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{

    public Text interactionText;
    public float raycastDistance = 2f;
    public Transform cameraTransform;

    private IInteractible selectedInteractible;


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
                selectedInteractible.Interact();

            }
        }
    }

    public void CheckInteractible() {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, raycastDistance))
        {
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
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * raycastDistance, Color.red);
    }
}





