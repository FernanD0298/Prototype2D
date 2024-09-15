using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigExtraInfo : MonoBehaviour
{
    public GameObject DataPref;
    public Transform ContentBox;
    public GameObject InfoButton;
    public GameObject ParentUI;
    public GameObject InfoPanel;

    [Header("Info Components")] 
    public RawImage Image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;
    public TextMeshProUGUI Info3;
    
    private CharactersData Data;

    private void Start()
    {
        Data = DataPref.GetComponent<CharactersData>();
    }

    private void OnEnable()
    {
        ClearContentBox();
        Info3.gameObject.SetActive(true);
        InfoPanel.SetActive(false);
    }

    public void SetupCharacterButtons()
    {
        ClearContentBox();

        for (int i = 0; i < Data.Characters.Count; i++)
        {
            Debug.Log(i);
            GameObject Button = Instantiate(InfoButton, ContentBox, true);
            Button.GetComponentInChildren<TextMeshProUGUI>().text = Data.Characters[i].Name;
            Character CharacterInfo = Data.Characters[i];
            Button.GetComponent<Button>().onClick.AddListener(delegate { ShowCharacterData(CharacterInfo); });
        }
    }
    
    public void SetupCardsButtons()
    {
        ClearContentBox();

        for (int i = 0; i < Data.CardsList.Count; i++)
        {
            GameObject Button = Instantiate(InfoButton, ContentBox, true);
            Button.GetComponentInChildren<TextMeshProUGUI>().text = Data.CardsList[i].Name;
            Cards Card = Data.CardsList[i];
            Button.GetComponent<Button>().onClick.AddListener(delegate { ShowCardData(Card); });
        }
    }
    
    public void SetupWeaponButtons()
    {
        ClearContentBox();

        for (int i = 0; i < Data.Characters.Count; i++)
        {
            GameObject Button = Instantiate(InfoButton, ContentBox, true);
            Button.GetComponentInChildren<TextMeshProUGUI>().text = Data.Characters[i].Weapon.Name;
            Character CharacterInfo = Data.Characters[i];
            Button.GetComponent<Button>().onClick.AddListener(delegate { ShowWeaponData(CharacterInfo); });
        }
    }

    void ShowCharacterData(Character Character)
    {
        Image.texture = Character.Image;
        Name.text = Character.Name;
        Description.text = Character.Description;
        Info1.text = "Damage: " + Character.CharacterInfo.DamageValue;
        Info2.text = "Speed: " + Character.CharacterInfo.SpeedValue;
        Info3.text = "Life: " + Character.CharacterInfo.LifeValue;
        
        InfoPanel.SetActive(true);
    }
    
    void ShowWeaponData(Character Character)
    {
        Image.texture = Character.Weapon.Image;
        Name.text = Character.Weapon.Name;
        Description.text = Character.Weapon.Description;
        Info1.text = "Damage: " + Character.Weapon.DamageValue;
        Info2.text = "Speed: " + Character.Weapon.SpeedValue;
        Info3.text = "KnockBack: " + Character.Weapon.KnockBackValue;
        
        InfoPanel.SetActive(true);
    }
    
    void ShowCardData(Cards Card)
    {
        Image.texture = Card.Image;
        Name.text = Card.Name;
        Description.text = Card.Description;
        Info1.text = "Upgrade: " + Card.Upgrade + "-" + Card.UpgradeStat;
        Info2.text = "Downgrade: " + Card.Downgrade + "-" + Card.DowngradeStat;
        Info3.gameObject.SetActive(false);
        
        InfoPanel.SetActive(true);
    }

    void ClearContentBox()
    {
        foreach (Transform transform in ContentBox)
        {
            Destroy(transform.gameObject);
        }
    }

    public void Close()
    {
        ParentUI.SetActive(false);
    }
}

