using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    Rigidbody2D rb;
	Animator anim;
	
    void Start()
    {
        
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		float xVel = Mathf.Abs(rb.velocity.x);
		anim.SetFloat("speed",xVel);

		
    }
}
