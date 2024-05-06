using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    GameObject player;
    PlayerStatus stats;

    [SerializeField]
    List<GameObject> inventory;
    [SerializeField]
    int capacity;
    
    [SerializeField]
    GameObject inventoryUI;
    [SerializeField]
    GameObject[] itemUI;
    [SerializeField]
    GameObject selectedItem = null;

    bool isOpen = false;

    
    void Start() {
        isOpen = false;
        player = GameObject.FindWithTag("Player");
        stats = player.GetComponent<PlayerStatus>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    
    void Update() {
        Inputs();
    }

    private void Inputs() {
        if (Input.GetButtonDown("Inventory")) {
            ToggleInventory();
        }
    }

    public bool Find(GameObject item) {
        foreach (GameObject gameItem in inventory) {
            if (gameItem.GetComponent<IItem>().GetType() == item.GetType()) {

                return true;
            }
        }
        return false;
    }

    public string GetKey()
    {
        if (selectedItem == null) {
            return "default";
        }
        return selectedItem.GetComponent<IItem>().Key();
    }

    public GameObject GetHolding()
    {
        if (selectedItem == null)
        {
            return null;
        }
        return selectedItem;
    }

    public bool tryAdd(GameObject item) {
       if (inventory.Count < capacity) {
            inventory.Add(item);
            RefreshInventory();
            return true;
        }

        return false;
    }

    public void Remove(GameObject item) {
        if (selectedItem != null) {
            DeselectAll();
            inventory.Remove(item);
            RefreshInventory();
        }


    }


    public void ToggleInventory() {
        if (isOpen)
        {
            CloseInventory();
            isOpen = false;
        }
        else
        {
            OpenInventory();
            isOpen = true;
        }
    }
    public void OpenInventory() {
        inventoryUI.SetActive(true);
        RefreshInventory();
        stats.SetLook(false);
        stats.SetMove(false);
        stats.SetInteract(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }
    public void CloseInventory() {
        inventoryUI.SetActive(false);
        stats.SetLook(true);
        stats.SetMove(true);
        stats.SetInteract(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    private void RefreshInventory() {
        for (int i = 0; i < itemUI.Length; i++)
        {
            InventoryItem invItem = itemUI[i].GetComponent<InventoryItem>();
            if (i < inventory.Count && inventory.Count != 0)
            {

                IItem gameItem = inventory[i].GetComponent<IItem>();
                invItem.SetItem(gameItem);
            }

            else
            {
                invItem.SetItem(null);
            }
        }
    }


    public void SelectItem(int pos) {
        try
        {
            for (int i = 0; i < itemUI.Length; i++)
            {
                InventoryItem itemLoop = itemUI[i].GetComponent<InventoryItem>();
                Debug.Log("balls " + pos);
                if (i == pos)
                {
                    if (itemLoop.CheckSelected())
                    {
                        itemLoop.Deselect();
                        selectedItem = null;
                    }
                    else
                    {
                        itemLoop.Select();
                        selectedItem = inventory[i];
                    }
                }
                else
                {
                    itemLoop.Deselect();
                }
            }
        }
        catch { }
    }
    public void DeselectAll() {

        for (int i = 0; i < itemUI.Length; i++) {
            InventoryItem itemLoop = itemUI[i].GetComponent<InventoryItem>();
            itemLoop.Deselect();
            selectedItem = null;
        }

    }

    public void DiscardItem() {
        if (selectedItem != null) {
            selectedItem.GetComponent<IInteractible>().Interact("discard");
            Remove(selectedItem);
        }
        
    }





}
