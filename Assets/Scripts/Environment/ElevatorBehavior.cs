using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : TogglableObject
{
    private bool canToggle = true;
    public List<GameObject> walls;
    private Vector3 startPosition;
    public Transform endPosition;
    public float speed;
    public GameObject lever;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach(GameObject wall in walls)
        {
            wall.SetActive(false);
        }
        startPosition = gameObject.transform.position;
        lever.SetActive(false);
    }

    private void Update()
    {
        if (player.gameObject.GetComponent<Player_Health>().isDead)
        {
            ResetElevator();
            Debug.Log("This should have happened");
            CancelInvoke();
            player.transform.SetParent(null, true);
            lever.SetActive(false);
            gameObject.transform.position = startPosition;
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
        }
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
            InvokeRepeating("MoveElevator", 0, .01f);
        }
 
    }

    public void ResetElevator()
    {
        canToggle = true;
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
