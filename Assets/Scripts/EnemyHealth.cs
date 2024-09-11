using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;

    public void TakeDamage(float DamageToTake)
    {
        Health -= DamageToTake;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        
        DamageNumberController.Instance.SpawnDamage(DamageToTake, transform.position);
    }
}
