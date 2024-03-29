﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Nathan - Created the code for basic movement.

    Eddie - Helped Nathan refine movement by showing refactoring some of the code and switching movement to velocity.
    Connor - Revised jumping to make it more responsive. Longer hold = longer jump. Raycast vs tag system.
     
     */


public class Player_Move : MonoBehaviour
{
    public LayerMask mask;
    public bool canMove = true;
    public float speed = 5f;
    public float jump = 5f;
    public float jumpVary;
    public bool onGround = true;
    private bool isMoving = false;
    public bool canBulletTime = false;
    private Rigidbody2D playerRB;
    public GameObject timeManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        if (canBulletTime)
        {
            timeManager.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerRB.velocity = new Vector2(speed * 1 * Time.deltaTime, playerRB.velocity.y);

                if (TimeManager.inBulletTime)
                {
                    playerRB.velocity = new Vector2(speed * -2 * Time.deltaTime, playerRB.velocity.y);
                }

                if (!isMoving)
                {
                    isMoving = true;
                    SoundManager.instance.PlaySound("Walk");
                }
            }

            else if (Input.GetKey(KeyCode.A))
            {
                playerRB.velocity = new Vector2(speed * -1 * Time.deltaTime, playerRB.velocity.y);

                if (TimeManager.inBulletTime)
                {
                    playerRB.velocity = new Vector2(speed * -2 * Time.deltaTime, playerRB.velocity.y);
                }

                if (!isMoving)
                {
                    isMoving = true;
                    SoundManager.instance.PlaySound("Walk");
                }
            }

            else
            {
                playerRB.velocity = new Vector2(0, playerRB.velocity.y);

                isMoving = false;
                SoundManager.instance.StopSound("Walk");
            }

            if (Physics2D.CircleCast(transform.position, .9f, Vector2.down, 1.75f, mask)) onGround = true;
            else onGround = false;
        }
    }

    private void Update()
    {
        if(canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jump);
                onGround = false;
                SoundManager.instance.PlaySound("Jump");
            }
        }

    }


}
