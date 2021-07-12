using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Guns
{
    public void MachineGunShoot()
    {
        if (GunRedyToFire())
        {
            ShootParticle();
            Shoot();
        }
    }
}
