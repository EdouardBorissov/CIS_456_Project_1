using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
                rb.constraints = RigidbodyConstraints2D.None;
                Debug.Log("object should have dropped found.");
            }

            foreach (GameObject gameObj in objectsToDestroy)
            {
                Debug.Log("object: " + gameObj.gameObject.name + " will be destroyed");
                Destroy(gameObj);
            }
        }
    }
}



