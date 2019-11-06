using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animate : MonoBehaviour
{
    Player_Move myMove;
    Rigidbody2D self;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Rigidbody2D>();
        myMove = GetComponent<Player_Move>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Moving", (self.velocity != Vector2.zero));
        anim.SetBool("Airborne", !myMove.onGround);
    }
}
