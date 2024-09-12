using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private GameObject Character;
    private GameObject Weapon;
    public int Money;

    public void AddMoney(int Amount)
    {
        Money += Amount;
    }

    public void SpendMoney(int Amount)
    {
        Money -= Amount;
    }
}
