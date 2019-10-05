using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    /*
     * Eddie Borissov
     * CIS_456
     * Project 2
     * 
     * Just a quick code to rotate any object by some amount at some frequency.
     * 
     */
    public float rotationAmount;
    public float rotationFrequency;
    // Start is called before the first frame update


    void Start()
    {
        InvokeRepeating("RotateObject", 0, rotationFrequency);
    }


    public void RotateObject()
    {
        gameObject.transform.Rotate(0, 0, rotationAmount);
    }
}
