using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeWeapons : MonoBehaviour
{
    public TextMeshProUGUI SpeedPrice;
    public TextMeshProUGUI DamagePrice;
    public TextMeshProUGUI KnockBackPrice;

    private InventoryManager InventoryManager;
    private Character CurrentCharacter;

    public void Start()
    {
        InventoryManager = global::InventoryManager.Instance;
        //CurrentCharacter = InventoryManager.CurrentCharacter;
    }

    public void SetUpgradePrice()
    {
       // SpeedPrice.text = (CurrentCharacter.Weapon.SpeedLevel * 10).ToString();
       // DamagePrice.text = (CurrentCharacter.Weapon.DamageLevel * 20).ToString();
        //KnockBackPrice.text = (CurrentCharacter.Weapon.KnockBackLevel * 30).ToString();
    }
    
    public void OnSpeedButton()
    {
        //InventoryManager.UpgradeWeaponSpeed();
    }

    public void OnDamageButton()
    {
        Debug.Log("Damage");
    }

    public void OnKnockBackButton()
    {
        Debug.Log("KnockBack");
    }
}


