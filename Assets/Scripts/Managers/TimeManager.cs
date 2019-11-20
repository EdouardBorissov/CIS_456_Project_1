using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private bool canBulletTime = false;

    private bool inBulletTime = false;

    public float bulletTimeLimit = 3.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && canBulletTime && !inBulletTime)
        {
            Time.timeScale = 0.5f;
            BulletTimeLimit(bulletTimeLimit);

        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    IEnumerator BulletTimeLimit(float time)
    {
        yield return new WaitForSeconds(time);

    }
}
