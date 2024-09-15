using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersData : MonoBehaviour
{
    public List<Character> Characters;
    public List<Cards> CardsList;
    public List<Gacha> GachaInfo;

    public void Awake()
    {
        Debug.Log("Load Data");
    }
}

[Serializable]
public struct Weapon
{
    public String Name;
    public Texture Image;
    public int DamageValue;
    public int SpeedValue;
    public float KnockBackValue;
    public String Description;
}

[Serializable]
public struct WeaponInfo
{
    public int DamageUpgradeValue;
    public int SpeedUpgradeValue;
    public float KnockBackUpgradeValue;

    public int DamageLevel;
    public int SpeedLevel;
    public int KnockBackLevel;

    public int DamagePrice;
    public int SpeedPrice;
    public int KnockBackPrice;

    public int DamageInitialStat;
    public int SpeedInitialStat;
    public float KnockBackInitialStat;
}

[Serializable]
public struct CharacterInfo
{
    public int DamageValue;
    public int SpeedValue;
    public int LifeValue;
}

[Serializable]
public struct Character
{
    public int ID;
    public String Name;
    public Texture Image;
    public GameObject PlayerPref;
    public WeaponInfo WeaponInfo;
    public Weapon Weapon;
    public CharacterInfo CharacterInfo;
    public string Description;
}

[Serializable]
public struct Cards
{
    public float ID;
    public String Name;
    public String Description;
    public int BelongsToPlayerID;
    public Texture Image;
    public int CardLevel;
    public int CardUpgradeValue;
    public int Upgrade;
    public CharacterStat UpgradeStat;
    public int Downgrade;
    public CharacterStat DowngradeStat;
}

[Serializable]
public struct Gacha
{
    public int BannerID;
    public List<GachaCards> CardsInBanner;
    public int Price;
}

[Serializable]
public struct GachaCards
{
    public int CardID;
    public float Probability;
}

[Serializable]
public enum CharacterStat
{
    Life,
    Damage,
    Speed
}