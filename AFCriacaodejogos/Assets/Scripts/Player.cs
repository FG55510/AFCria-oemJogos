using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public float force = 5;
    public float torque = 2;

    public Vector2 velocity; // <-------------------------------

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        rb.AddForce(transform.right * ver * force);
        rb.AddTorque(-hor * torque);

        velocity = rb.velocity;    // <-------------------------------
    }


}
