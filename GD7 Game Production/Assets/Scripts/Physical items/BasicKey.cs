using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKey : MonoBehaviour, IInteractible
{

    //An item that can be picked up and used to interact with objects.

    GameObject player;
    [SerializeField]
    PlayerInventory inventory;


   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inventory = FindObjectOfType<PlayerInventory>();
    }
    public string GetDisplayText(string key)
    {
        return ("interact to pick up");
    }

    public void Interact(string key)
    {
        if (key == "discard")
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
            gameObject.SetActive(true);
            Debug.Log("ADF");

        }

        else if (key == "destroyKey") {
            gameObject.SetActive(false);
            inventory.Remove(gameObject);
        }

        else if (inventory.tryAdd(gameObject))
        {
            Debug.Log("added");
            gameObject.SetActive(false);
        }
    }

    public void CanInteract(bool state)
    {
        if (state)
        {

            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Collider>().enabled = true;
        }
        else {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }
        
    }
}
