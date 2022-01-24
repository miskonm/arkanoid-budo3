using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float Speed;
    public Vector2 Direction;
    
    [Header("Debug")]
    public Vector2 DirectionNormalized;
    public float Velocity;

    private void Start()
    {
        DirectionNormalized = Direction.normalized;
        Rb.velocity = Direction.normalized * Speed;
    }

    private void Update()
    {
        Velocity = Rb.velocity.magnitude;
        // Rb.velocity = new Vector2(0, 10);
    }
}
