using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglableRotate : TogglableObject
{
    public float rotationAmount;
    public float rotationFrequency;
    // Start is called before the first frame update

    void Start()
    {
        if (toggledOn)
            InvokeRepeating("RotateObject", 0, rotationFrequency);
    }


    public void RotateObject()
    {
        gameObject.transform.Rotate(0, 0, rotationAmount);
    }

    public override void Toggle()
    {
        Debug.Log("Rotator recieved Toggle");
        toggledOn = !toggledOn;
        if (toggledOn)
            InvokeRepeating("RotateObject", 0, rotationFrequency);
        else
            CancelInvoke();
    }
}
