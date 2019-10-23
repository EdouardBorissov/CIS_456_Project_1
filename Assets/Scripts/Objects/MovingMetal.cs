using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMetal : MonoBehaviour
{
    public Vector2 startingPosition;
    public Vector2 endingPosition;

    public float t = 0.0f;
    private float direction = 1.0f;

    public float metalMoveSpeed;

    private Transform child;

    void Start()
    {
        t = 0.0f;
        //child = transform.GetChild(0);
    }


    void Update()
    {
        t += Time.deltaTime * metalMoveSpeed * direction;

        if (t > 1.0f)
        {
            t = 1.0f;
            direction = -1.0f;
        }
        else if (t < 0.0f)
        {
            t = 0.0f;
            direction = 1.0f;
        }


        transform.localPosition = Vector2.Lerp(startingPosition, endingPosition, t);
    }
}
