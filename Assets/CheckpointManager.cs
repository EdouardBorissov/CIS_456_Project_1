using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector2 startingPosition;
    public GameObject NewestCheckpoint;

    public static CheckpointManager instance;


    void Start()
    {
        instance = this;
        startingPosition = transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            LoadToLastCheckpoint();
        }
    }

    public void setNewCheckpoint(GameObject newCheckpoint)
    {
        NewestCheckpoint = newCheckpoint;
        newCheckpoint.tag = "Untagged";
    }

    public void LoadToLastCheckpoint()
    {
        if (NewestCheckpoint == null)
        {
            transform.position = startingPosition;
        }
        else
        {
            transform.position = NewestCheckpoint.transform.position;
        }
    }

     private void OnTriggerEnter2D(Collider2D other) 
     {
         Debug.Log("Entered Checkpoint");
        if (other.gameObject.tag == "Checkpoint")
        {
            setNewCheckpoint(other.gameObject);
        }
    }
}
