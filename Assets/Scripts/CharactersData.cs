using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersData : MonoBehaviour
{
    public List<Character> Characters;
    public List<Cards> CardsList;
}

[Serializable]
public struct Weapon
{
    public int DamageValue;
    public int SpeedValue;
    public int KnockBackValue;
}

[Serializable]
public struct WeaponInfo
{
    public int DamageUpgradeValue;
    public int SpeedUpgradeValue;
    public int KnockBackUpgradeValue;

    public int DamageInitialStat;
    public int SpeedInitialStat;
    public int KnockBackInitialStat;
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
    public GameObject PlayerPref;
    public WeaponInfo WeaponInfo;
    public Weapon Weapon;
    public CharacterInfo CharacterInfo;
    public string Description;
}

[Serializable]
public struct Cards
{
    public int ID;
    public Texture Image;
    public int CardLevel;
    public int CardUpgradeValue;
    public int Upgrade;
    public CharacterStat UpgradeStat;
    public int Downgrade;
    public CharacterStat DowngradeStat;
}

[Serializable]
public enum CharacterStat
{
    Life,
    Damage,
    Speed
}