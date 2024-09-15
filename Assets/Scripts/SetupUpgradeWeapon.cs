using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetupUpgradeWeapon : MonoBehaviour
{
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI KnockBackText;
    public TextMeshProUGUI DamagePrice;
    public TextMeshProUGUI SpeedPrice;
    public TextMeshProUGUI KnockBackPrice;

    public GameObject ParentUI;
    
    private InventoryManager InventoryManager;

    private void OnEnable()
    {
        if(!InventoryManager)
            InventoryManager = InventoryManager.Instance;

        UpdateWeaponInfo();
    }

    void UpdateWeaponInfo()
    {
        DamageText.text = InventoryManager.CurrentCharacterInfo.Weapon.DamageValue.ToString();
        SpeedText.text = InventoryManager.CurrentCharacterInfo.Weapon.SpeedValue.ToString();
        KnockBackText.text = InventoryManager.CurrentCharacterInfo.Weapon.KnockBackValue.ToString();

        DamagePrice.text = (InventoryManager.CurrentCharacterInfo.WeaponInfo.DamagePrice *
                            InventoryManager.CurrentCharacterInfo.WeaponInfo.DamageLevel).ToString();
        SpeedPrice.text = (InventoryManager.CurrentCharacterInfo.WeaponInfo.SpeedPrice *
                           InventoryManager.CurrentCharacterInfo.WeaponInfo.SpeedLevel).ToString();
        KnockBackPrice.text = (InventoryManager.CurrentCharacterInfo.WeaponInfo.KnockBackPrice *
                               InventoryManager.CurrentCharacterInfo.WeaponInfo.KnockBackLevel).ToString();
    }

    public void UpgradeDamage()
    {
        if(!InventoryManager.Instance.CheckIfHaveEnoughMoney(int.Parse(DamagePrice.text))) return;

        InventoryManager.CurrentCharacterInfo.WeaponInfo.DamageLevel++;
        
        InventoryManager.CurrentCharacterInfo.Weapon.DamageValue +=
            InventoryManager.CurrentCharacterInfo.WeaponInfo.DamageUpgradeValue *
            InventoryManager.CurrentCharacterInfo.WeaponInfo.DamageLevel;
        
        UpdateWeaponInfo();
    }

    public void UpgradeSpeed()
    {
        if(!InventoryManager.Instance.CheckIfHaveEnoughMoney(int.Parse(SpeedPrice.text))) return;
        
        InventoryManager.CurrentCharacterInfo.WeaponInfo.SpeedLevel++;

        InventoryManager.CurrentCharacterInfo.Weapon.SpeedValue +=
            InventoryManager.CurrentCharacterInfo.WeaponInfo.SpeedUpgradeValue *
            InventoryManager.CurrentCharacterInfo.WeaponInfo.SpeedLevel;
        
        UpdateWeaponInfo();
    }

    public void UpgradeKnockBack()
    {
        if(!InventoryManager.Instance.CheckIfHaveEnoughMoney(int.Parse(KnockBackPrice.text))) return;
        
        InventoryManager.CurrentCharacterInfo.WeaponInfo.KnockBackLevel++;

        InventoryManager.CurrentCharacterInfo.Weapon.KnockBackValue +=
            InventoryManager.CurrentCharacterInfo.WeaponInfo.KnockBackUpgradeValue *
            InventoryManager.CurrentCharacterInfo.WeaponInfo.KnockBackLevel;
        
        UpdateWeaponInfo();
    }

    public void Close()
    {
        InventoryManager.UpdateWeaponStats();
        
        ParentUI.SetActive(false);
    }
}
