using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMechanism : MonoBehaviour, IInteractible
{
    public GameObject drawer;
    public float speed = 5.0f; // Public speed for movement (adjustable)
    public float offset = 1.0f; // Public offset for movement relative to initial position
    public bool open = false; // Flag to control whether the drawer is open or closed

    [SerializeField]
    Transform pos;

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
    [SerializeField]
    bool isCorrect = false;
    bool isLocked = false;


    Vector3 initialPosition; // Private variable to store the initial position of the drawer
    Vector3 targetPosition; // Private variable to store the target position of the drawer

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();

        // Store the initial position of the drawer
        initialPosition = drawer.transform.position;

        // Calculate the target position based on the offset
        targetPosition = initialPosition + transform.right * offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            MoveDrawer(targetPosition);
        }
        else
        {
            MoveDrawer(initialPosition);
        }

        if (itemRef != null)
        {

            PlaceItem();
            itemRef.GetComponent<IInteractible>().CanInteract(false);
        }
        

    }

    public bool IsOpen() {
        return open;
    }

    // Move the drawer to the specified target position
    void MoveDrawer(Vector3 targetPosition)
    {
        Vector3 currentPosition = drawer.transform.position;

        // Calculate movement towards the target position
        Vector3 movement = (targetPosition - currentPosition).normalized * speed * Time.deltaTime;

        // Update position smoothly
        drawer.transform.position += movement;

        // Constrain movement within specified limits
        float minX = Mathf.Min(currentPosition.x, targetPosition.x);
        float maxX = Mathf.Max(currentPosition.x, targetPosition.x);
        currentPosition.x = Mathf.Clamp(drawer.transform.position.x, minX, maxX);

        float minY = Mathf.Min(currentPosition.y, targetPosition.y);
        float maxY = Mathf.Max(currentPosition.y, targetPosition.y);
        currentPosition.y = Mathf.Clamp(drawer.transform.position.y, minY, maxY);

        float minZ = Mathf.Min(currentPosition.z, targetPosition.z);
        float maxZ = Mathf.Max(currentPosition.z, targetPosition.z);
        currentPosition.z = Mathf.Clamp(drawer.transform.position.z, minZ, maxZ);

        // Update position while considering constraints
        drawer.transform.position = currentPosition;
    }

    public string GetDisplayText(string key)
    {
        if (isLocked)
        {
            if (reqKey == key) {
                return "interact to unlock";
            }
            return "use key to unlock";
        }
        else if (!open) {
            return "interact to open";
        }
        else if (itemRef != null)
        {
            return "interact to pick up";
        }
        return "interact to close";
    }
    public void Interact(string key)
    {
        if (isLocked)
        {
            if (reqKey == key)
            {
                SetLock(false);
            }
        }
        else if (!open)
        {
            open = true;
        }
        else if (itemRef != null)
        {
            itemRef.GetComponent<IInteractible>().CanInteract(true);
            itemRef.GetComponent<IInteractible>().Interact("interact");
            itemRef = null;
        }
        else {
            open = false;
        }

    }

    public void SetLock(bool locked)
    {
        isLocked = locked;
    }
    public bool GetCorrect()
    {
        return isCorrect;
    }

    private void PlaceItem()
    {
        itemRef.transform.position = pos.transform.position;
        itemRef.transform.rotation = pos.transform.rotation;
        itemRef.SetActive(true);
    }

    public void CanInteract(bool state)
    {
        if (state) {
            gameObject.GetComponent<Collider>().enabled = true;
        }
            gameObject.GetComponent<Collider>().enabled = false;
    }
}
