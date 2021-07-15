using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Guns
{
    bool playerIsHoldingTrigger=false;
    void Update()
    {
        if (playerIsHoldingTrigger)
            MachineGunShoot();
    }
    public void MachineGunShoot()
    {
        if (GunRedyToFire())
        {
            Shoot();
        }
    }
    public void GetTriggerState(bool buttonIsDown) => playerIsHoldingTrigger = buttonIsDown;
}
