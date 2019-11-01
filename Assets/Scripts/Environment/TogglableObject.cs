using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TogglableObject : MonoBehaviour
{
    public bool toggledOn;

    public abstract void Toggle();
}
