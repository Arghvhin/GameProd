using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItem
{
    string Name();
    string Key();
    string Description();
    Image Image();
}
