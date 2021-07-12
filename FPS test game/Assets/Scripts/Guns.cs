using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    float range;
    [SerializeField]
    protected float fireRate;
    [SerializeField]
    float impactForce;
    Camera mainCamera;

    void Awake()
    {
        mainCamera = GetComponentInChildren<Camera>();
    }
    protected void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log("hit object "+ hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
                target.TakeDamage(damage);
            if (hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal* impactForce);
        }
    }
}
