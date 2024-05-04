using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    [SerializeField]
    GameObject selected;
    [SerializeField]
    TMP_Text nameText;
    [SerializeField]
    TMP_Text descText;

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
            nameText.text = item.Name();
            descText.text = item.Description();
        }

        else {
            Debug.Log("gers");
            GetComponent<Image>().sprite = null;
            nameText.text = "";
            descText.text = "";
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
