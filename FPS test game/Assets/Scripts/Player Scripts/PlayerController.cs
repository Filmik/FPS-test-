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
    SmallGun smallGun;
    MachineGun machineGun;
    GrenadeThrow grenadeThrow;
    WeaponSwitching weaponSwitching;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        mouseLook = GetComponent<MouseLook>();
        playerGravity = GetComponent<PlayerGravity>();
        smallGun = GetComponent<SmallGun>();
        machineGun = GetComponent<MachineGun>();
        grenadeThrow = GetComponent<GrenadeThrow>(); 
        weaponSwitching= GetComponentInChildren<WeaponSwitching>();
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

    public void OnShoot(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            smallGun.SmallGunShoot();
            machineGun.MachineGunShoot();
            grenadeThrow.ThrowGrenade();
            //animationController.playerAttack();
        }
    }
    public void OnJump(InputAction.CallbackContext value)
    {
        playerGravity.Jump();
       // animationController.playerJumpUp(true);
    }
    public void OnChangeWeapons(InputAction.CallbackContext value)
    {
        if (value.started)
            weaponSwitching.ChangeToNextWeapon();
    }
}
