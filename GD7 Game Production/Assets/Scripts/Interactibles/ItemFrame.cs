using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFrame : MonoBehaviour, IInteractible
{

    // A frame that activates itself when the correct item is used on it.

    [SerializeField]
    Transform pos;

    [SerializeField]
    string reqKey;
    [SerializeField]
    string noKeyText;
    [SerializeField]
    string hasKeyText;

    [SerializeField]
    GameObject itemRef;
    GameObject player;
    PlayerInventory inventory;
    [SerializeField]
    bool isCorrect = false;
    bool isLocked = false;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (itemRef != null) {
            PlaceItem();
        }
    }

    public string GetDisplayText(string key)
    {
        if (isLocked) {
            return "cannot interact";
        }
        if (itemRef == null)
        {
            if (key != "default")
            {
                return "interact to place";
            }
            return "hold item to place";
        }
        return "interact to remove";
    }

    public void Interact(string key)
    {
        if (!isLocked) { 
            if (key == reqKey)
            {
                isCorrect = true;

            }
            else
            {
                isCorrect = false;

            }

            if (itemRef == null)
            {
                if (key != "default") {
                    itemRef = inventory.GetHolding();

                    itemRef.SetActive(true);
                    itemRef.GetComponent<IInteractible>().CanInteract(false);
                    inventory.Remove(itemRef);
                }
                
            }
            else if (inventory.tryAdd(itemRef))
            {
                itemRef.SetActive(false);
                itemRef.GetComponent<IInteractible>().CanInteract(true);
                itemRef = null;
            }
        }

    }

    public void SetLock(bool locked) {
        isLocked = locked;
    }
    public bool GetCorrect() {
        return isCorrect;
    }

    private void PlaceItem() {
        
        itemRef.transform.position = pos.transform.position;
        itemRef.transform.rotation = pos.transform.rotation;
    }

    public void CanInteract(bool state)
    {
        if (state)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
