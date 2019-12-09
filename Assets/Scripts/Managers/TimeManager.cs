using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static bool inBulletTime = false;

    public float bulletTimeLimit = 3.0f;

    private GameObject player;

    private GameObject bullet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.F)) && !inBulletTime)
        {
            Debug.Log("DFSDFSDF");
            Time.timeScale = 0.5f;
            inBulletTime = true;
            StartCoroutine(BulletTimeLimit(bulletTimeLimit));
        }
    }

    IEnumerator BulletTimeLimit(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("ssssssssssssssssssss");
        Time.timeScale = 1.0f;
        player.gameObject.GetComponent<Rigidbody2D>().velocity /= 2;
        inBulletTime = false;
    }
}
