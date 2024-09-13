using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake()
    {
        CharactersData CharactersData = CharacterDataPref.GetComponent<CharactersData>(); 
        InitialData(CharactersData);
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void InitialData(CharactersData Data)
    {
        Characters = Data.Characters;
        CardsList.Add(Data.CardsList[0]);
        CardsList.Add(Data.CardsList[1]);
        CardsList.Add(Data.CardsList[2]);
        CardsList.Add(Data.CardsList[3]);
        CardEquipped1 = Data.CardsList[2];
        CardEquipped2 = Data.CardsList[3];
    }

    public GameObject CharacterDataPref;
    public List<Character> Characters;
    public List<Cards> CardsList;
    public Cards CardEquipped1;
    public Cards CardEquipped2;
    public int Money;
    public int CurrentCharacterID = 1;

    private void Start()
    {
        //TODO: Load from file if exist
    }

    public void UpgradeWeaponSpeed(int Speed)
    {
    }
    
    public void UpgradeWeaponDamage(int Damage)
    {
    }
    
    public void UpgradeWeaponKnockBack(int KnockBack)
    {
    }

    public void AddMoney(int Amount)
    {
        Money += Amount;
    }

    public void SpendMoney(int Amount)
    {
        Money -= Amount;
    }
}


