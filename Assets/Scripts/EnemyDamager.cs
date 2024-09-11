using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float DamageAmount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<EnemyHealth>())
        {
            col.GetComponent<EnemyHealth>().TakeDamage(DamageAmount);
        }
    }
}
