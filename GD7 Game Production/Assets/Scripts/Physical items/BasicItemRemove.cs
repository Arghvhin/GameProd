using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItemRemove : MonoBehaviour, IInteractible
{
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
        inventory = FindObjectOfType<PlayerInventory>();
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

    public void CanInteract(bool state)
    {
        if (state)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
