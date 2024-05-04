using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetText(string text) { 
        GetComponent<Text>().text = text; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
