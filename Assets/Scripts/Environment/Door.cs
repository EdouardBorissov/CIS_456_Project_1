using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TogglableObject
{
    public Vector2 openPos;
    public Vector2 closePos;
    public float openZRot;
    public float closeZRot;
    private Vector2 currentPos;
    private float currentZRot;

    private void Start()
    {
    }

    public override void Toggle(bool set)
    {
        Debug.Log("Door recieved Toggle");
        toggledOn = set;

        if(toggledOn == true)
        {
            Open();
        }

        if(toggledOn == false)
        {
            Close();
        }
    }

    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(OpenCloseLerp(closePos, openPos));
    }

    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(OpenCloseLerp(openPos, closePos));
    }

    public IEnumerator OpenCloseLerp(Vector2 startPos, Vector2 movetoPos)
    {
        currentPos = startPos;
        while (currentPos!= movetoPos)
        {
            currentPos = Vector2.Lerp(transform.position, movetoPos, .125f);
            transform.position = currentPos;
            yield return null;
        }
    }
}
