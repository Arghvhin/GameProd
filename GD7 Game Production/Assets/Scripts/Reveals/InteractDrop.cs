using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDrop : MonoBehaviour, IInteractible
{
    float initialPos;
    public void CanInteract(bool state)
    {
        if (state)
        {

            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Collider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }

    }

    public string GetDisplayText(string key)
    {
        return ("interact");
    }

    public void Interact(string key)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < initialPos - 30) {
            Destroy(gameObject);
        }
        
    }
}
