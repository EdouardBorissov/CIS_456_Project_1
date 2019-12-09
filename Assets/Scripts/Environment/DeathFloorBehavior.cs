using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Eddie B
     */

public class DeathFloorBehavior : MonoBehaviour
{
    public bool canKill = true;
    public float damage = 100f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" && canKill)
        {
            collision.gameObject.GetComponent<Player_Health>().DamagePlayer(damage);
        }
    }
}
