using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractibleHide : MonoBehaviour, IInteractible
{

    private bool isHidden = false;

    public CinemachineVirtualCamera activeCam;


    public string GetInteractionText()
    {
        if (isHidden)
        {
            return "Press E to leave";
        }
        else {
            return "Press E to hide";
        }
    }

  
    public void Interact()
    {
        if (!isHidden)
        {

            activeCam.Priority = 2;
            isHidden = true;
        }
        else
        {
            activeCam.Priority = 0;
            isHidden = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
