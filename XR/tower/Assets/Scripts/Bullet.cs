using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null) {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject); // Destroy the bullet on impact
        }
    }
}
