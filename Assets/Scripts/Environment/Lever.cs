/* HOW TO USE: 
 * If given a timeToClose less than or equal to 0, the lever will toggle on and off whenever it is shot
 * 
 * If given a timeToClose greater than 0, the  lever will toggle off after that many seconds
 * 
 * Any object inheriting from TogglableObject can be toggled by the lever, simply add it to the list of objectsToToggle
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public List<TogglableObject> objectsToToggle;
    public bool state;
    public float timeToClose = 0;
    private Collider2D leverCollider;

    private void Start()
    {
        leverCollider = gameObject.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            leverCollider.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            Debug.Log("Lever Hit");

            if (state && timeToClose > 0)
            {
                StopAllCoroutines();

                foreach (TogglableObject gameObj in objectsToToggle)
                {
                    Debug.Log(gameObj.name + " was refreshed");
                    StartCoroutine(Timer(timeToClose, gameObj));
                }
            }

            else
            {

                foreach ( TogglableObject gameObj in objectsToToggle)
                {
                    Debug.Log(gameObj.name + " was toggled");
                    
                    gameObj.Toggle();
                    if (timeToClose > 0)
                        StartCoroutine(Timer(timeToClose, gameObj));
                }
            }
        }
    }

    IEnumerator Timer(float time, TogglableObject itemToClose)
    {
        yield return new WaitForSeconds(time);
        itemToClose.Toggle();
        leverCollider.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
