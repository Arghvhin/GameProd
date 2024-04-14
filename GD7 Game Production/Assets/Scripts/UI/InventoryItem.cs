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
        Sprite sprite = null;
        
        if (item != null) {
            sprite = Resources.Load<Sprite>(item.Image());

            if (sprite != null) {
                GetComponent<Image>().sprite = sprite;
            }
        }

        else {
            GetComponent<Image>().sprite = null;
        }
    }

    public string GetName()
    {
        return item.Name();
    }

    public string GetDescription() {
        return item.Description();
    }

    public void Select() {
        selected.SetActive(true);
    }

    public void Deselect()
    {
        selected.SetActive(false);
    }



}
