using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float Damage;

    public float HitWaitTime = 0f;
    private float HitCounter;

    private void FixedUpdate()
    {
        if (HitCounter > 0)
        {
            HitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var Player = col.gameObject.GetComponent<PlayerHealth>();
        if (Player)
        {
            Player.TakeDamage(Damage);

            HitCounter = HitWaitTime;
        }
    }
}
