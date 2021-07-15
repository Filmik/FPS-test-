using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGun : Guns
{
    public void SmallGunShoot()
    {
        if (GunRedyToFire())
        {
            Shoot();
        }
    }
    public void SmallGunZoom(bool buttonIsDown) =>Zoom(buttonIsDown);
}
