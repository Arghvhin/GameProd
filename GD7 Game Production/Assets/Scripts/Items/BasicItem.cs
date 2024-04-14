using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicItem : MonoBehaviour, IItem
{
    [SerializeField]
    string name;
    [SerializeField]
    string key;
    [SerializeField]
    string description;
    [SerializeField]
    Image image;
    public string Name()
    {
        return name;
    }
    public string Description()
    {
        return description;
    }

    public Image Image()
    {
        return image;
    }

    public string Key()
    {
        return key;
    }

    
}
