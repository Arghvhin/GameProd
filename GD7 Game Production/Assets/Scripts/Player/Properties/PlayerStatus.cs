using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    GameObject player;
    MeshRenderer mesh;
    PlayerMovement movement;
   

    private bool isHidden = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movement = player.GetComponent<PlayerMovement>();
        mesh = player.GetComponent<MeshRenderer>();
        isHidden = false;
    }

    public bool ReturnHidden() {
        return isHidden;
            }
    public void Hide() {
        movement.enabled = false;
        mesh.enabled = false;
    }
    public void Unhide()
    {
        StartCoroutine(IEUnhide());
    }

    IEnumerator IEUnhide()
    {
        yield return new WaitForSeconds(1);
        movement.enabled = true;
        mesh.enabled = true;
    }
}
