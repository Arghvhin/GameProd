using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public bool screenres;
    public int hres = 480;
    public int vres = 320;
    // Start is called before the first frame update
    void Start()
    {
        if (screenres)
        {

            Screen.SetResolution(hres, vres, FullScreenMode.FullScreenWindow);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
