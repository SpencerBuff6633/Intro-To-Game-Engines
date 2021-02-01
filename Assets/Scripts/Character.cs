using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Character : MonoBehaviour
{
    [Range(0, 20)] public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-2, 20)] public float gravity = -9.8f;
    public Animator animator;
    bool onGround = false;

    CharacterController characterController;
    Vector3 inputDirection;
    Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = characterController.isGrounded;
        if(onGround && velocity.y < 0)
        {
            velocity.y = 0;
        }

        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion rotation = Quaternion.AngleAxis(cameraRotation.eulerAngles.y, Vector3.up);
        Vector3 direction = rotation * inputDirection;

        characterController.Move(direction * speed * Time.deltaTime);

        if(inputDirection.magnitude > 0.1f)
        {
            //transform.forward = inputDirection.normalized;
            Quaternion target = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 5);

        }
        animator.SetFloat("Speed", inputDirection.magnitude);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

    public void OnJump()
    {
        if (onGround && velocity.y < 0)
        {
            velocity.y = 0;
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 v2 = input.Get<Vector2>();
        inputDirection.x = v2.x;
        inputDirection.z = v2.y;
    }
}
