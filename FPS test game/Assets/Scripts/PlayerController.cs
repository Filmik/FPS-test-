using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    float movementSpeed = 1;
    [SerializeField]
    float jumpForce = 5;
    [SerializeField]
    float mouseSensitivity = 100f;
    [SerializeField]
    float clampYMin = -90;
    [SerializeField]
    float clampYMax = 90;
    float xRotation;
    Vector2 inputMovement;
    Vector3 move;
    CharacterController controller;
    //PlayerAnimationController animationController;
    Rigidbody _rigidbody;
    Transform playerTransform;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        playerTransform = transform;
       // animationController = GetComponent<PlayerAnimationController>();
    }

    void Update()
    {
        if (inputMovement != Vector2.zero)
        {
            move = transform.right * inputMovement.x + transform.forward * inputMovement.y;
            controller.Move(move * movementSpeed * Time.deltaTime);
        }
    }
    public void OnMouse(InputAction.CallbackContext value)//On mouse movement
    {
        Vector2 mousePos = value.ReadValue<Vector2>();
        float mouseX = mousePos.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mousePos.y * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,clampYMin,clampYMax);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
        //if (runMovement != 0)
        //    animationController.playerRun();
        //else
        //    animationController.playerStopRuning();

    }

    //public void OnAttack(InputAction.CallbackContext value)
    //{
    //    if (value.started)
    //    {
    //        animationController.playerAttack();
    //    }
    //}
    //public void OnJump(InputAction.CallbackContext value)
    //{
    //    if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
    //    {
    //        _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    //        animationController.playerJumpUp(true);
    //    }
    //}
}
