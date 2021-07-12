using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    float durability;

    public void TakeDamage(float amount)
    {
        durability -= amount;
        if (durability <= 0f)
            Die();
    }
    void Die() => Destroy(gameObject);
}
