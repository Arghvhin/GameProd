using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

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

    public bool tryAdd(GameObject item) {
       if (inventory.Count < capacity) {
            inventory.Add(item);
            return true;
        }

        return false;
    }

    public void Remove(GameObject item) {
        inventory.Remove(item);


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
        for (int i = 0; i < itemUI.Length; i++) {
            Debug.Log("wa" + i);
            Debug.Log("inv" + inventory.Count);
            InventoryItem invItem = itemUI[i].GetComponent<InventoryItem>();
            if (i < inventory.Count && inventory.Count != 0) {

                IItem gameItem = inventory[i].GetComponent<IItem>();
                invItem.SetItem(gameItem);
            }
            
            else {
                invItem.SetItem(null);
            }
        }

    }
    public void CloseInventory() {
        inventoryUI.SetActive(false);
    }


    public void SelectItem(int pos) {

        for (int i = 0; i < itemUI.Length; i++) {
            InventoryItem itemLoop = itemUI[i].GetComponent<InventoryItem>();
            if (i == pos) {
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
            else {
                itemLoop.Deselect();
            }
        }
       
    }
    public void DeselectAll() {

        for (int i = 0; i < itemUI.Length; i++) {
            InventoryItem itemLoop = itemUI[i].GetComponent<InventoryItem>();
            itemLoop.Deselect();
            selectedItem = null;
        }

    }

    public void DiscardItem() {
        
    }





}
