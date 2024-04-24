using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    [SerializeField]
    GameObject selected;

    private IItem item;

    public IItem GetItem() {
        return item;
    }


    public void SetItem(IItem newItem) {
        item = newItem;
        
        if (item != null) {
            Debug.Log("pog");
            GetComponent<Image>().enabled = true;
            GetComponent<Image>().sprite = item.Image().sprite;
        }

        else {
            Debug.Log("gers");
            GetComponent<Image>().enabled = false;
        }
    }

    public string GetName()
    {
        return item.Name();
    }

    public string GetDescription() {
        return item.Description();
    }

    public bool CheckSelected() {
        if (selected.activeSelf) {
            return true;
        }
        return false;
    }
    public void Select() {
        selected.SetActive(true);
    }

    public void Deselect()
    {
        selected.SetActive(false);
    }



}
