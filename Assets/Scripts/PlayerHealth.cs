using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        }

        HealthSlider.value = CurrentHealth;
    }
}
