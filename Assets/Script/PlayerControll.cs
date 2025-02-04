﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
public float movementSpeed;
    public float jumpForce;
    private float inputMovement;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Start(){ 
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }

        if(Input.GetMouseButtonDown(0) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetMouseButtonDown(0) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        inputMovement = Input.acceleration.x;
        rb.velocity = new Vector2(inputMovement * movementSpeed, rb.velocity.y);

        if (facingRight == false && inputMovement > 0){
            Flip();
        } else if (facingRight == true && inputMovement < 0){
            Flip();
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
