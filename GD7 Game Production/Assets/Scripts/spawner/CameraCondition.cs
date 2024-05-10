using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCondition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    ItemFrame[] frames;
    [SerializeField]
    CinemachineVirtualCamera vcamera;
    [SerializeField]
    float lingerTime;
    [SerializeField]
    Transform camera;
    [SerializeField]
    PlayerStatus status;
    public bool debugTrue = false;
    [SerializeField]
    Transform playerCamera;
    [SerializeField]
    GameObject door;
    [SerializeField]
    GameObject[] enemy;



    [SerializeField]
    bool correctTriggered = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!correctTriggered) {
            int correctAmount = 0;
            foreach (var frame in frames)
            {
                if (frame.GetCorrect())
                {
                    correctAmount++;
                }
            }
            if (correctAmount == frames.Length || debugTrue)
            {
                door.SetActive(false);
                foreach (var senemy in enemy)
                { 
                    senemy.SetActive(false);}
                foreach (var frame in frames) {
                    frame.SetLock(true);
                }
                status.Hide();
                vcamera.Priority = 2;
                if (Vector3.Distance(vcamera.transform.position, camera.position) < 0.1f)
                {
                    lingerTime -= Time.deltaTime;

                    
                }
            }
            if (lingerTime < 0)
            {

                vcamera.Priority = 0;
                if (Vector3.Distance(playerCamera.position, camera.position) < 0.1f)
                {
                    status.Unhide();
                    Debug.Log("back yo uoi");
                    correctTriggered = true;
                    foreach (var senemy in enemy)
                    {
                        senemy.SetActive(true);
                    }
                }

            }
        }
        
    }
}
