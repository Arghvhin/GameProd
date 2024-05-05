using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public float gravity;
    public bool screenres;
    public int hres;
    public int vres;
    // Start is called before the first frame update
    void Start()
    {
        if (screenres)
        {

            Screen.SetResolution(hres, vres, FullScreenMode.FullScreenWindow);
        }
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
