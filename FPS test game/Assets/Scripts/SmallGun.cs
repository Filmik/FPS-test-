using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGun : Guns
{
    [SerializeField]
    GameObject smallGun;
    [SerializeField]
    ParticleSystem shotFlashParticles;
    float nextTimeToFire = 0f;
    public void SmallGunShoot()
    {
        if (smallGun.activeSelf&& Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shotFlashParticles.Play();
            Shoot();
        }
    }
}
