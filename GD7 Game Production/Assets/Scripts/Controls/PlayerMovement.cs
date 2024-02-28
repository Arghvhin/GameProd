using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed = 7f;
    public float jumpForce = 3f;
    public float acceleration = 50f;

    [SerializeField]
    Vector3 moveY;

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
            moveY.y = -2;
        }

        Inputs();
        moveY.y += gravity * Time.deltaTime;

        // Lerping acceleration
        //Vector3 targetMoveDirection = moveDirection.normalized * moveSpeed;
        //moveDirection = Vector3.Lerp(moveDirection, targetMoveDirection, acceleration * Time.deltaTime);

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        characterController.Move(moveY * Time.deltaTime);


    }

    private void Inputs()
    {
        moveDirection = Vector3.Scale(cameraOrientation.forward, new Vector3(1, 0, 1)).normalized * Input.GetAxis("Vertical") +
            Vector3.Scale(cameraOrientation.right, new Vector3(1, 0, 1)).normalized * Input.GetAxis("Horizontal");
        if (groundedPlayer)
            if (Input.GetButtonDown("Jump"))
            {
                moveY.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
            }
    }


}
