using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible
{

    void Interact(string key);

    string GetDisplayText(string key);

    void CanInteract(bool state);
}

