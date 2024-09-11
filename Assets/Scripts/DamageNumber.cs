using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI DamageText;

    public float LifeTime;
    private float LifeCounter;
    public float FloatSpeed = 1f;

    void Update()
    {
        if (LifeCounter > 0)
        {
            LifeCounter -= Time.deltaTime;
            if (LifeCounter <= 0)
            {
                DamageNumberController.Instance.PlaceInPool(this);
            }
        }
        
        transform.position += Vector3.up * (FloatSpeed * Time.deltaTime);
    }

    public void Setup(int DamageDisplay)
    {
        LifeCounter = LifeTime;
        DamageText.text = DamageDisplay.ToString();
    }
}
