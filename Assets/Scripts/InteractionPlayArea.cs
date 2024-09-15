using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionPlayArea : MonoBehaviour
{
    public GameObject InteractionWidget;
    private bool IsCollide;
    private GameObject PlayerRef;
    public String Section;

    
    void Update()
    {
        if (IsCollide)
        {
            InteractionWidget.transform.position = PlayerRef.transform.position;

            if (Input.GetKey(KeyCode.E))
            {
                IsCollide = false;
                SceneManager.LoadScene("Level01", LoadSceneMode.Single);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InteractionWidget.SetActive(true);
            TextMeshProUGUI InteractText = InteractionWidget.GetComponentInChildren<TextMeshProUGUI>();
            InteractText.text = "Press E To Go to " + Section;
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
