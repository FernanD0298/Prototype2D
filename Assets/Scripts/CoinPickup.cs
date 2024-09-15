using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int Value;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Player")) return;
        
        InventoryManager.Instance.AddMoney(Value);
        Destroy(gameObject);
    }
}
