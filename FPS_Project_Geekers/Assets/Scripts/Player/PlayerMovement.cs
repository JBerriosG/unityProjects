using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    //Fuerza de velocidad
    [SerializeField] private float speed = 10f;

    private float gravity = -9.81f;

    Vector3 velocity;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private float sphereRadius = 0.3f;

    [SerializeField] private LayerMask groundMask;

    bool isGrounded;

    [SerializeField] private float jumpHeight = 3f;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
