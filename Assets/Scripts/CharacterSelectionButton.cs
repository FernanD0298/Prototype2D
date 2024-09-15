using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class CharacterSelectionButton : MonoBehaviour
{
    public GameObject PlayerPref;
    public Transform CurrentView;
    public Transform NextView;
    public GameObject CloseButton;
    public int CharacterID;

    public void ChangeCharacter()
    {
        GameObject Player = FindObjectOfType<PlayerMovement>().gameObject;
        GameObject Camera = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
        Transform CurrentTransform = Player.transform;
        Destroy(Player);

        GameObject NewPlayer = Instantiate(PlayerPref, CurrentTransform.position, quaternion.identity);
        Camera.GetComponent<CinemachineVirtualCamera>().Follow = NewPlayer.transform;

        InventoryManager.Instance.CurrentCharacterID = CharacterID;

        for (int i = 0; i < InventoryManager.Instance.Characters.Count; i++)
        {
            if (InventoryManager.Instance.Characters[i].ID == CharacterID)
            {
                InventoryManager.Instance.CurrentCharacterInfo = InventoryManager.Instance.Characters[i];
            }
        }
        
        CurrentView.gameObject.SetActive(false);
        NextView.gameObject.SetActive(true);
        CloseButton.SetActive(true);
    }
}
