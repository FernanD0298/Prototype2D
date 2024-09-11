using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float Speed;
    public Animator Animator;
    

    void FixedUpdate()
    {
        Vector3 MoveInput = new Vector3(0f, 0f, 0f);

        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");

        MoveInput.Normalize();

        Rigidbody2D.velocity = MoveInput * Speed;

        if (MoveInput != Vector3.zero)
        {
            Animator.SetBool("Move", true);
        }
        else
        {
            Animator.SetBool("Move", false);
        }
    }
}
