using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            
            //grab the bullet's rigidbody
            Rigidbody2D bulletRB = gameObject.GetComponent<Rigidbody2D>();

            Debug.Log("Old Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());
            //change the velocity based on where this wall is facing
            bulletRB.velocity = (Vector3.Reflect(bulletRB.velocity, collision.contacts[0].normal).normalized) * bulletSpeed * Time.deltaTime;

            Debug.Log("New Velocity " + bulletRB.velocity.x.ToString() + " " + bulletRB.velocity.y.ToString());

        }
    }

    public void SetBulletSpeed(float newSpeed)
    {
        bulletSpeed = newSpeed;
    }
}
