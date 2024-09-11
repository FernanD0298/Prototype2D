using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float MoveSpeed;
    private Transform Target;
    
    void Start()
    {
        Target = FindObjectOfType<PlayerMovement>().transform;

        MoveSpeed *= Random.Range(0.7f, 1.4f);
    }
    
    void FixedUpdate()
    {
        if (!Target.gameObject.activeSelf)
        {
            Rigidbody2D.velocity = Vector2.zero;
            return;
        }
        
        Rigidbody2D.velocity = (Target.position - transform.position).normalized * MoveSpeed;
    }
}
