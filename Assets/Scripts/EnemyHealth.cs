using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour
{
    public float Health;
    
    private float KnockBackCounter;

    public float ChangeToDrop = 100f;
    public List<GameObject> DropItems;

    private void Update()
    {
        if (KnockBackCounter > 0)
        {
            KnockBackCounter -= Time.deltaTime;

            float MoveSpeed = gameObject.GetComponent<EnemyMovement>().MoveSpeed;
            if (MoveSpeed > 0)
            {
                gameObject.GetComponent<EnemyMovement>().MoveSpeed = -MoveSpeed * 2f;
            }

            if (KnockBackCounter <= 0)
            {
                gameObject.GetComponent<EnemyMovement>().MoveSpeed = Mathf.Abs(MoveSpeed * 0.5f);
            }
        }
    }

    public void TakeDamage(float DamageToTake)
    {
        Health -= DamageToTake;

        if (Health <= 0)
        {
            if (Random.Range(1, 100) < ChangeToDrop)
            {
                GameObject ItemToDrop = DropItems[Random.Range(1, DropItems.Count) - 1];
                Instantiate(ItemToDrop, gameObject.transform.position, quaternion.identity);
            }
            
            Destroy(gameObject);
        }
        
        DamageNumberController.Instance.SpawnDamage(DamageToTake, transform.position);
    }

    public void TakeDamage(float DamageToTake, bool ShouldKnockBack, float KnockBackTime)
    {
        TakeDamage(DamageToTake);

        if (ShouldKnockBack)
        {
            KnockBackCounter = KnockBackTime;
        }
    }
}
