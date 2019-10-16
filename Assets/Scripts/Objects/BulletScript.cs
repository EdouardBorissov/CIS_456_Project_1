using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    /*
    Warren Guiles
    BulletScript
    CIS_456_Project_1
    This script mainly handles bullet richochet by changing the velocity of the bullet when it collides with a wall.    
     */

    private float bulletSpeed;


    //how many times the bullet bounces before it destroys itself
    //(if it's 0 it will bounce for forever)
    public int bounceLimit;

    private float numberOfBounces = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //grab the bullet's rigidbody
            Rigidbody2D bulletRB = gameObject.GetComponent<Rigidbody2D>();

            //  Debug.Log("Old Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());

            //change the velocity based on where this wall is facing

            bulletRB.velocity = (Vector2.Reflect(bulletRB.velocity, collision.contacts[0].normal).normalized) * (bulletSpeed / 2) * Time.deltaTime;

            // Debug.Log("New Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());

            SoundManager.instance.PlayRandomRicochet();

            numberOfBounces++;

            if (numberOfBounces > bounceLimit && bounceLimit != 0)
            {
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.CompareTag("Rust"))
        {

            Destroy(collision.gameObject);
            //grab the bullet's rigidbody
            Rigidbody2D bulletRB = gameObject.GetComponent<Rigidbody2D>();

            //  Debug.Log("Old Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());

            //change the velocity based on where this wall is facing

            bulletRB.velocity = (Vector2.Reflect(bulletRB.velocity, collision.contacts[0].normal).normalized) * (bulletSpeed / 2) * Time.deltaTime;

            // Debug.Log("New Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());

            SoundManager.instance.PlayRandomRicochet();

            numberOfBounces++;

            if (numberOfBounces > bounceLimit && bounceLimit != 0)
            {
                Destroy(gameObject);
            }
        }
        //destroy bullets that hit the player
        else if (!collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Chain"))
        {
            Destroy(gameObject);
        }


    }

    //setter for bullet speed
    public void SetBulletSpeed(float newSpeed)
    {
        bulletSpeed = newSpeed;
    }
}
