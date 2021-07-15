using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    bool hasExploded = false;
    [SerializeField]
    GameObject explosionEffect;
    [SerializeField]
    float destroyExplosionTime = 1f;
    [SerializeField]
    float radius = 2f;
    [SerializeField]
    float explosionForce = 500f;
    [SerializeField]
    float damage = 50;
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded && collision.gameObject.layer==Constants.Layers.ground)
            Explode();
    }
    void Explode()
    {
        GameObject explosionObject= Instantiate(explosionEffect,transform.position,transform.rotation);
        Collider[] colliders= Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            //Do damage to Target objects
            Target target = nearbyObject.GetComponent<Target>();
            if (target != null)
                target.TakeDamage(damage);

            //Add force to rigidbody objects
            Rigidbody rb= nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(explosionForce,transform.position,radius);
        }
        Destroy(explosionObject, destroyExplosionTime);
        Destroy(gameObject);
    }
}
