using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItemRemove : MonoBehaviour, IInteractible
{
    //an item that gets removed when the correct key is passed.

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
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetDisplayText(string key)
    {
        if (key == reqKey)
        {
            return hasKeyText;
        }
        else return noKeyText;
    }

    public void Interact(string key)
    {
        if (key == reqKey)
        {
            gameObject.SetActive(false);
            inventory.Remove(itemRef);
        }
    }

    
}
