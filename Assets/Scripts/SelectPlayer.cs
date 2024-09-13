using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public GameObject DataPref;
    private CharactersData Data;
    public GameObject SelectPlayerButton;
    public GameObject SelectCharacterUI;
    public Transform SelectCharacterBox;

    public Transform CurrentCanvas;
    public Transform NextCanvas;
    
    void Start()
    {
        Data = DataPref.GetComponent<CharactersData>();
        SetupSelectPlayerMenu();  
    }

    void SetupSelectPlayerMenu()
    {
        for (int i = 0; i < Data.Characters.Count; i++)
        {
            GameObject Button = Instantiate(SelectPlayerButton, SelectCharacterBox, true);
            Button.GetComponentInChildren<TextMeshProUGUI>().text = "Player " + Data.Characters[i].ID;
            CharacterSelectionButton SelectionButton = Button.GetComponent<CharacterSelectionButton>();
            SelectionButton.PlayerPref = Data.Characters[i].PlayerPref;
            SelectionButton.CurrentView = CurrentCanvas;
            SelectionButton.NextView = NextCanvas;
            SelectionButton.CharacterID = Data.Characters[i].ID;
        }
    }

    public void Close()
    {
        SelectCharacterUI.SetActive(false);
    }
}
