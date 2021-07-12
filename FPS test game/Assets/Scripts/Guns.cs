using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField]
    protected GameObject gun;
    [SerializeField]
    ParticleSystem shotParticles;
    [SerializeField]
    float damage;
    [SerializeField]
    float range;
    [SerializeField]
    protected float fireRate;
    [SerializeField]
    float impactForce;
    Camera mainCamera;
    float nextTimeToFire = 0f;
    void Awake()
    {
        mainCamera = GetComponentInChildren<Camera>();
    }
    protected void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log("hit object " + hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
                target.TakeDamage(damage);
            if (hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * impactForce);
        }
    }
    protected bool GunRedyToFire()
    {
        if (gun.activeSelf && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            return true;
        }
        return false;
    }
    protected void ShootParticle()
    {
        shotParticles.Play();
    }
}
