using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    GameObject player;
    MeshRenderer mesh;
    PlayerMovement movement;
    CinemachineBrain camera;

   

    bool isHidden = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movement = player.GetComponent<PlayerMovement>();
        mesh = player.GetComponent<MeshRenderer>();
        camera = GameObject.FindWithTag("Camera brain").GetComponent<CinemachineBrain>();
        isHidden = false;
    }

    public bool ReturnHidden() {
        return isHidden;
            }
    public void Hide() {
        SetMove(false);
        mesh.enabled = false;
    }
    public void Unhide()
    {
        StartCoroutine(IEUnhide());
    }

    IEnumerator IEUnhide()
    {
        yield return new WaitForSeconds(1);
        SetMove(true);
        mesh.enabled = true;
    }

    public bool CanLook() {
        return camera.enabled;
    }
    public void SetLook(bool enabled) {
        camera.enabled = enabled;
    }
    public bool CanMove()
    {
        return movement.enabled;
    }
    public void SetMove(bool enabled)
    {
        movement.enabled = enabled;
    }
    
}
