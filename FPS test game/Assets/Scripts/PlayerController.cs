using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //PlayerAnimationController animationController;
    PlayerMovement playerMovement;
    MouseLook mouseLook;
    PlayerGravity playerGravity;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        mouseLook = GetComponent<MouseLook>();
        playerGravity = GetComponent<PlayerGravity>();
       // animationController = GetComponent<PlayerAnimationController>();
    }
    public void OnMouse(InputAction.CallbackContext value)//On mouse movement
    {
        Vector2 mousePos = value.ReadValue<Vector2>();
        mouseLook.CameraMove(mousePos);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        playerMovement.GetMoveVector(inputMovement);
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
    public void OnJump(InputAction.CallbackContext value)
    {
        playerGravity.Jump();
       // animationController.playerJumpUp(true);
    }
}
