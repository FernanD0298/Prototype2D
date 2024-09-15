using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake()
    {
        CharactersData CharactersData = CharacterDataPref.GetComponent<CharactersData>(); 
        InitialData(CharactersData);
        
        if(WillSpawnPlayer)
            SpawnPlayer();
        
        Instance = this;
        
        UpdateCharacterStat();
        UpdateWeaponStats();
        
        DontDestroyOnLoad(this.gameObject);
    }

    public bool WillSpawnPlayer = false;

    void SpawnPlayer()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            if (Characters[i].ID == CurrentCharacterID)
                Instantiate(Characters[i].PlayerPref, transform.position, quaternion.identity);
        }
    }

    public void UpdateCharacterStat()
    {
        GameObject Player = FindObjectOfType<PlayerMovement>().gameObject;
        if (Player)
        {
            PlayerMovement Movement = Player.GetComponent<PlayerMovement>();
            Movement.Speed = CurrentCharacterInfo.CharacterInfo.SpeedValue;
            PlayerHealth Health = Player.GetComponent<PlayerHealth>();
            Health.MaxHealth = CurrentCharacterInfo.CharacterInfo.LifeValue;
            Health.UpdateCurrentHealth();
            
        }
    }

    public void UpdateWeaponStats()
    {
        RotationWeapon RotationWeapon = FindObjectOfType<RotationWeapon>();
        RotationWeapon.RotateSpeed = CurrentCharacterInfo.Weapon.SpeedValue;
        EnemyDamager Damager = FindObjectOfType<EnemyDamager>();
        Damager.DamageAmount = CurrentCharacterInfo.Weapon.DamageValue + CurrentCharacterInfo.CharacterInfo.DamageValue;
        Damager.KnockBackTime = CurrentCharacterInfo.Weapon.KnockBackValue;

        Character NewCharacter = CurrentCharacterInfo;
        for (int i = 0; i < Characters.Count; i++)
        {
            if (Characters[i].ID == CurrentCharacterID)
            {
                Characters[i] = NewCharacter;
                break;
            }
        }
    }

    void InitialData(CharactersData Data)
    {
        Characters = Data.Characters;
        
        for (int i = 0; i < Characters.Count; i++)
        {
            if (Characters[i].ID == CurrentCharacterID)
            {
                CurrentCharacterInfo = Characters[i]; 
                break;
            }
        }
        
        CardsList.Add(Data.CardsList[0]);
        CardsList.Add(Data.CardsList[1]);
        CardsList.Add(Data.CardsList[2]);
        CardsList.Add(Data.CardsList[3]);
        //CardEquipped1 = Data.CardsList[2];
        //CardEquipped2 = Data.CardsList[3];
    }

    public GameObject CharacterDataPref;
    public List<Character> Characters;
    public List<Cards> CardsList;
    public Cards CardEquipped1;
    public Cards CardEquipped2;
    public int Money;
    public int CurrentCharacterID = 1;
    public Character CurrentCharacterInfo;

    private void Start()
    {
        //TODO: Load from file if exist
    }

    public void AddCard(Cards CardInfo)
    {
        bool UpgradeCard = false;
        
        for (int i = 0; i < CardsList.Count; i++)
        {
            if (CardsList[i].ID == CardInfo.ID)
            {
                Cards NewCard = CardsList[i];
                NewCard.CardLevel++;
                NewCard.Upgrade += (NewCard.CardLevel * NewCard.CardUpgradeValue);
                NewCard.ID += 0.01f;
                CardsList[i] = NewCard;
                UpgradeCard = true;
                break;
            }
        }
        
        if(!UpgradeCard)
            CardsList.Add(CardInfo);
        
        CheckCardsToCombine();
    }

    void CheckCardsToCombine()
    {
        bool CardCombined = false;
        for (int i = 0; i < CardsList.Count; i++)
        {
            for (int j = 0; j < CardsList.Count; j++)
            {
                if(i == j) continue;
                
                if (CardsList[i].ID == CardsList[j].ID)
                {
                    Cards NewCard = CardsList[i];
                    NewCard.CardLevel++;
                    NewCard.Upgrade += (NewCard.CardLevel * NewCard.CardUpgradeValue);
                    NewCard.ID += 0.01f;
                    CardsList[i] = NewCard;
                    CardsList.RemoveAt(j);
                    CardCombined = true;
                    break;
                }
            }
            if(CardCombined)
                CheckCardsToCombine();
        }
    }

    public void AddMoney(int Amount)
    {
        Money += Amount;
    }

    void SpendMoney(int Amount)
    {
        Money -= Amount;
    }

    public bool CheckIfHaveEnoughMoney(int Cost)
    {
        if (Money >= Cost)
        {
            SpendMoney(Cost);
            return true;
        }

        return false;
    }
}


