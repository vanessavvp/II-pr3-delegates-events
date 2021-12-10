using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody rb;
    Vector3 movement;

    void Start() 
    {
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            movement = new Vector3(0.0f, 0.0f, 1.0f);
        } else if (Input.GetKey(KeyCode.D)) 
        {
            movement = new Vector3(1.0f, 0.0f, 0.0f);
        } else if (Input.GetKey(KeyCode.S)) 
        {
            movement = new Vector3(0.0f, 0.0f, -1.0f);
        } else if (Input.GetKey(KeyCode.A)) 
        {
            movement = new Vector3(-1.0f, 0.0f, 0.0f);
        } 

        rb.position += movement * speed * Time.deltaTime;
    }
}
