using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;
    public float xOffset = 0;
    public float yOffset = 0;
    public static CameraManager instance;

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
        transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, -10);
    }
}
