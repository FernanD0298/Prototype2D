using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float CurrentHealth;
    public float MaxHealth;

    public Slider HealthSlider;

    private void Awake()
    {
        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = MaxHealth;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
        }

        HealthSlider.value = CurrentHealth;
    }

    public void UpdateCurrentHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
