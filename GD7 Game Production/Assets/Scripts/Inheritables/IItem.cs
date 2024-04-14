using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItem
{
    string Name();
    string Description();
    string Image();
    int GetCount();
    bool tryAdd(int count);
    bool tryRemove(int count);
}
