using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleBasicItem : MonoBehaviour, IInteractible
{

    GameObject player;
    PlayerInventory inventory;


   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();
    }
    public string GetDisplayText()
    {
        return ("interact to pick up");
    }

    public void Interact(string key)
    {
        if (inventory.tryAdd(gameObject)) {
            gameObject.SetActive(false);
        }
    }
}
