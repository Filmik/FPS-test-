using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [SerializeField]
    GameObject grenade;
    [SerializeField]
    int ammo = 3;
    [SerializeField]
    float throwForce = 40f;
    [SerializeField]
    GameObject grenadePrefab;

    public void ThrowGrenade()
    {
        if (grenade.activeSelf) 
        {
            Instantiate(grenadePrefab, transform.position, transform.rotation);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce);
        }
    }
}
