using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement Parameters")]
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f * 2;
    [SerializeField] private float jumpHeight = 3f;

    [Header("Layer Ground")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;


    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 move;
    private float x;
    private float z;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // move
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}
