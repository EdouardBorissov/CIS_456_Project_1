using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    /*
    Warren Guiles
    CIS_456_Project_1

    This script mainly handles bullet richochet by changing the velocity of the bullet when it collides with a wall.    
     */

    private float bulletSpeed;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //grab the bullet's rigidbody
          Rigidbody2D bulletRB = gameObject.GetComponent<Rigidbody2D>();

            Debug.Log("Old Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());
            //change the velocity based on where this wall is facing

            bulletRB.velocity = (Vector2.Reflect(bulletRB.velocity, collision.contacts[0].normal).normalized) * bulletSpeed * Time.deltaTime;

            Debug.Log("New Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());

        }
        else if(!collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void SetBulletSpeed(float newSpeed)
    {
        bulletSpeed = newSpeed;
    }
}
