using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
    public float RotateSpeed;
    
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (RotateSpeed * Time.deltaTime));
    }
}
