using System.Collections;
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
    public float speed = 5f;
    public float jump = 5f;
    public float jumpVary;
    public bool onGround = true;
    private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        //transform.position = new Vector2(-12, -3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(speed * Time.deltaTime, playerRB.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(speed * Time.deltaTime * -1, playerRB.velocity.y);
        }
        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }

        if (Physics2D.Raycast(transform.position, Vector2.down, 2, mask)) onGround = true;
        else onGround = false;

        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jump);
            onGround = false;
        }

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
