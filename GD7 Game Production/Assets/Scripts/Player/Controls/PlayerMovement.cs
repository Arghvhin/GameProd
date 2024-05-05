using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed = 7f;
    public float jumpForce = 3f;
    public float acceleration = 5f;
    public float snapStrength = -2f;

    [SerializeField]
    Vector3 move;

    private CharacterController characterController;
    public Vector3 moveDirection;
    public bool isJumping = false;
    public float gravity = -9.8f;


    public Transform cameraOrientation;


    public bool groundedPlayer;
   
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer)
        {
            moveDirection.y = snapStrength;
        }

        Inputs();
        moveDirection.y += gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
       

    }

    private void Inputs()
    {
        move = Vector3.Scale(cameraOrientation.forward, new Vector3(1, 0, 1)).normalized * Input.GetAxis("Vertical") +
            Vector3.Scale(cameraOrientation.right, new Vector3(1, 0, 1)).normalized * Input.GetAxis("Horizontal");
        characterController.Move(move.normalized * moveSpeed * Time.deltaTime);
        if (groundedPlayer)
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
    }


}
