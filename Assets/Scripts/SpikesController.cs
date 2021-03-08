using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thurst = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.up * thurst;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
