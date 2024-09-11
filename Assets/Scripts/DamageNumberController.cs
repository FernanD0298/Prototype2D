using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public DamageNumber NumberToSpawn;
    public Transform NumberCanvas;

    private List<DamageNumber> NumberPool = new List<DamageNumber>();

    public void SpawnDamage(float DamageAmount, Vector3 Location)
    {
        int Rounded = Mathf.RoundToInt(DamageAmount);

        DamageNumber NewDamage = GetFromPool();
        
        NewDamage.Setup(Rounded);
        NewDamage.gameObject.SetActive(true);

        NewDamage.transform.position = Location;
    }

    public DamageNumber GetFromPool()
    {
        DamageNumber NumeberToOutput = null;

        if (NumberPool.Count == 0)
        {
            NumeberToOutput = Instantiate(NumberToSpawn, NumberCanvas);
        }
        else
        {
            NumeberToOutput = NumberPool[0];
            NumberPool.RemoveAt(0);
        }

        return NumeberToOutput;
    }

    public void PlaceInPool(DamageNumber NumberToPlace)
    {
        NumberToPlace.gameObject.SetActive(false);
        
        NumberPool.Add(NumberToPlace);
    }
}
