﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float jumpHeight = 15f;
    private bool facingleft = true;
    private Collider2D coll;
    private Rigidbody2D rb;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (facingleft)
        {
            // test to see if they are befound the leftCap
            if (transform.position.x > leftCap)
            { // make sure that the sprite is facing the right way if not make it face the right direction
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                // test to if player can jump
                if (coll.IsTouchingLayers(ground))
                {

                    rb.velocity = new Vector2(-jumpLength, jumpHeight);

                }
            }
            else
            {
                facingleft = false;
            }

        }
        else
        {
            if (transform.position.x < rightCap)
            { // make sure that the sprite is facing the right way if not make it face the right direction
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                // test to if player can jump
                if (coll.IsTouchingLayers(ground))
                {

                    rb.velocity = new Vector2(jumpLength, jumpHeight);

                }
            }
            else
            {
                facingleft = true;
            }
        }
    }
}
