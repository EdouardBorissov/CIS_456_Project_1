using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : TogglableObject
{
    private bool canToggle = true;
    public List<GameObject> walls;
    public Transform endPosition;
    public float speed;
    public GameObject lever;

    private void Start()
    {
        foreach(GameObject wall in walls)
        {
            wall.SetActive(false);
        }

        lever.SetActive(false);
    }

    public override void Toggle()
    {
        if(canToggle)
        {
            canToggle = false;
            foreach (GameObject wall in walls)
            {
                wall.SetActive(true);
            }
            InvokeRepeating("MoveElevator", 0, .025f);
        }
 
    }

    private void MoveElevator()
    {
        if(gameObject.transform.position.y >= endPosition.position.y)
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }

            CancelInvoke();
        }
        else
        {
            transform.Translate(0f, speed, 0);
        }
    

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(gameObject.transform, true);
            lever.SetActive(true);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null,true);
            lever.SetActive(false);
        }
    }
}
