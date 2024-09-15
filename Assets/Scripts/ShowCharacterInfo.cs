using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCharacterInfo : MonoBehaviour
{
    public TextMeshProUGUI Damage;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Life;

    public Transform Slot1;
    public Transform Slot2;

    private InventoryManager InventoryManager;
    Character Character;

    private void OnEnable()
    {
        InventoryManager = global::InventoryManager.Instance;
        
        for (int i = 0; i < InventoryManager.Characters.Count; i++)
        {
            if (InventoryManager.Characters[i].ID == InventoryManager.CurrentCharacterID)
            {
                Character = InventoryManager.Characters[i];
            }
        }

        Damage.text = Character.CharacterInfo.DamageValue.ToString();
        Speed.text = Character.CharacterInfo.SpeedValue.ToString();
        Life.text = Character.CharacterInfo.LifeValue.ToString();
        
        UpdateSlotsValues();
    }

    public void RestartValues()
    {
        Damage.text = Character.CharacterInfo.DamageValue.ToString();
        Speed.text = Character.CharacterInfo.SpeedValue.ToString();
        Life.text = Character.CharacterInfo.LifeValue.ToString();
    }

    public void UpdateSlotsValues()
    {
        SetupCardInfo CardInfo = Slot1.GetComponentInChildren<SetupCardInfo>();
        if(CardInfo)
            UpdateValues(CardInfo);
        CardInfo = Slot2.GetComponentInChildren<SetupCardInfo>();
        if(CardInfo)
            UpdateValues(CardInfo);
    }

    void UpdateValues(SetupCardInfo CardInfo)
    {
        switch (CardInfo.CardInfo.UpgradeStat)
        {
            case CharacterStat.Damage:
                UpdateDamageValue(CardInfo.CardInfo.Upgrade);
                break;
            case CharacterStat.Life:
                UpdateLifeValue(CardInfo.CardInfo.Upgrade);
                break;
            case CharacterStat.Speed:
                UpdateSpeedValue(CardInfo.CardInfo.Upgrade);
                break;
        }
        
        switch (CardInfo.CardInfo.DowngradeStat)
        {
            case CharacterStat.Damage:
                UpdateDamageValue(CardInfo.CardInfo.Downgrade);
                break;
            case CharacterStat.Life:
                UpdateLifeValue(CardInfo.CardInfo.Downgrade);
                break;
            case CharacterStat.Speed:
                UpdateSpeedValue(CardInfo.CardInfo.Downgrade);
                break;
        }
    }

    public void UpdateDamageValue(int ExtraValue)
    {
        int NewValue = int.Parse(Damage.text) + ExtraValue;
        Damage.text = NewValue.ToString();
    }

    public void UpdateSpeedValue(int ExtraValue)
    {
        int NewValue = int.Parse(Speed.text) + ExtraValue;
        Speed.text = NewValue.ToString();
    }

    public void UpdateLifeValue(int ExtraValue)
    {
        int NewValue = int.Parse(Life.text) + ExtraValue;
        Life.text = NewValue.ToString();
    }

    public void UpdatePlayerStats()
    {
        int NewSpeed = int.Parse(Speed.text);
        int NewDamage = int.Parse(Damage.text);
        int NewLife = int.Parse(Life.text);

        InventoryManager.CurrentCharacterInfo.CharacterInfo.SpeedValue = NewSpeed;
        InventoryManager.CurrentCharacterInfo.CharacterInfo.LifeValue = NewLife;
        InventoryManager.CurrentCharacterInfo.CharacterInfo.DamageValue = NewDamage;
        
        InventoryManager.UpdateCharacterStat();
        InventoryManager.UpdateWeaponStats();
    }
}
