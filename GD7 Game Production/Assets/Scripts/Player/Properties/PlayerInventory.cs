using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    List<IItem> inventory;
    [SerializeField]
    int capacity;
    
    [SerializeField]
    GameObject inventoryUI;
    [SerializeField]
    GameObject[] itemUI; 

    IItem selectedItem = null;

    
    void Start() {
        
    }

    
    void Update() {
        
    }

    public IItem Find(IItem item) {
        foreach (IItem invItem in inventory) {
            if (invItem.GetType() == item.GetType()) {
                return invItem;
            }
        }
        return null;
    }

    public bool tryAdd(IItem item, int count) {
        /*
         when try add item, check if iitem already exists in array. 
        if no initialize item, else IItem.tryAdd. If fail, return false
         */
        IItem invItem = Find(item);

        if (invItem != null)
        {
            return invItem.tryAdd(count);
            
        }
        else if (inventory.Count < capacity) {
            inventory.Add(item);
            return inventory[inventory.Count - 1].tryAdd(count);
        }

        return false;
    }

    public void tryRemove(IItem item, int count) {
        IItem invItem = Find(item);

        if (invItem != null)
        {
            if (invItem.tryRemove(count)) {
                inventory.Remove(invItem);
            }
        }

    }

    public void openInventory() {
        inventoryUI.SetActive(true);
        for (int i = 0; i < itemUI.Length; i++) {
            InventoryItem invItem = itemUI[i].GetComponent<InventoryItem>();
            invItem.SetItem(inventory[i]);
            invItem.Deselect();
        }

    }
    public void closeInventory()
    {
        selectedItem = null;
        inventoryUI.SetActive(false);
    }


    public void SelectItem(InventoryItem invItem) {

        for (int i = 0; i < itemUI.Length; i++) {
            InventoryItem itemLoop = itemUI[i].GetComponent<InventoryItem>();
            if (itemLoop.GetItem().GetType() == invItem.GetItem().GetType()) {
                itemLoop.Select();
                selectedItem = inventory[i];
            }
            else {
                itemLoop.Deselect();
            }
        }
       
    }
    public void UseItem(string id)
    {

    }
    public void DiscardItem()
    {

    }





}
