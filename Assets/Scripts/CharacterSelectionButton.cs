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
        
        CurrentView.gameObject.SetActive(false);
        NextView.gameObject.SetActive(true);
    }
}
