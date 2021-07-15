using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField]
    protected GameObject gun;
    [SerializeField]
    AudioClip gunShot;
    AudioSource audioSource;
    [SerializeField]
    ParticleSystem shotParticles;
    [SerializeField]
    GameObject impactEffect;
    [SerializeField]
    float delayToDestroyImpacctEffect;
    [SerializeField]
    float damage;
    [SerializeField]
    float range;
    [SerializeField]
    protected float fireRate;
    [SerializeField]
    float impactForce;
    float nextTimeToFire = 0f;
    Camera mainCamera;
    float defaultFieldOfView;
    [SerializeField]
    float zoomPower=0;//how much gun will zoom
    void Awake()
    {
        mainCamera = GetComponentInChildren<Camera>();
        defaultFieldOfView = mainCamera.fieldOfView;
        audioSource = gun.GetComponent<AudioSource>();
        audioSource.clip = gunShot;
    }
    protected void Shoot()
    {

        ShootParticle();
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log("hit object " + hit.transform.name);
            GameObject impactObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, delayToDestroyImpacctEffect);// 
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
        audioSource.Play();
    }
    protected void Zoom(bool buttonIsDown)
    {
        if (buttonIsDown&&zoomPower > 0)
            mainCamera.fieldOfView = defaultFieldOfView - zoomPower;
        if (!buttonIsDown)
            mainCamera.fieldOfView = defaultFieldOfView;
    }
}
