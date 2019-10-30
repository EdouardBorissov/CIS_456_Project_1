using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  * Eddie Borissov
  * CIS_456
  * Project 2
  * 
  * A simple script that allows a shot object to make others drop and others to be destroyed.
  * 
  */

public class BagOfGoldBehavior : MonoBehaviour
{
    public List<GameObject> objectsToDestroy;
    public List<Rigidbody2D> objectsToFall;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision detected.");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bullet found.");

            foreach (Rigidbody2D rb in objectsToFall)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.constraints = RigidbodyConstraints2D.None;
                Debug.Log("object should have dropped found.");
            }

            foreach (GameObject gameObj in objectsToDestroy)
            {
                Debug.Log("object: " + gameObj.gameObject.name + " will be destroyed");
                Destroy(gameObj);
            }

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}



