using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractibleHide : MonoBehaviour, IInteractible
{
    GameObject player;
    PlayerStatus playerStatus;

    private bool isHidden = false;


    [SerializeField]
    CinemachineVirtualCamera activeCam;

    bool queueUnhide = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public string GetDisplayText()
    {
        if (isHidden)
        {
            return "Press E to leave";
        }
        else {
            return "Press E to hide";
        }
    }

  
    public void Interact(string key)
    {
        if (!isHidden)
        {

            activeCam.Priority = 2;
            isHidden = true;
            playerStatus.Hide();
        }
        else
        {
            activeCam.Priority = 0;
            isHidden = false;
            playerStatus.Unhide();

        }
    }

    
}
