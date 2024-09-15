using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionLobby : MonoBehaviour
{
    public GameObject WidgetToOpen;
    public GameObject InteractionWidget;
    public String Section;
    private GameObject PlayerRef;
    private bool IsCollide;
    
    void Update()
    {
        if (IsCollide)
        {
            InteractionWidget.transform.position = PlayerRef.transform.position;

            if (Input.GetKey(KeyCode.E))
            {
                WidgetToOpen.SetActive(true);
                IsCollide = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InteractionWidget.SetActive(true);
            TextMeshProUGUI InteractText = InteractionWidget.GetComponentInChildren<TextMeshProUGUI>();
            InteractText.text = "Press E To Open " + Section;
            IsCollide = true;
            PlayerRef = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionWidget.SetActive(false);
            IsCollide = false;
            PlayerRef = null;
        }

    }
}
