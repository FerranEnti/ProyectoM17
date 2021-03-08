﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    private float baseSpeed = 3.0f;
    //private float maxSpeed = 8.0f;

    private float currentSpeedV = 0.0f;
    private float currentSpeedH = 0.0f;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        float rand = Random.Range(0.0f, 1.0f);
        if (rand < 0.5)
        {
            currentSpeedH = -baseSpeed;
        }
        else
        {
            currentSpeedH = baseSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000; ;
        rigidBody.velocity = new Vector2(currentSpeedH, currentSpeedV) * delta;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            currentSpeedH *= -1; 
        }
        
        
    }
}
