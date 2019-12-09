using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100f;
    public bool isDead = false;
    public float respawnDelay = 2;
   // public Image healthBar;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
       // healthBar.fillAmount = 1.0f;
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            currentHealth -= 20;
          //  healthBar.fillAmount = currentHealth / maxHealth;
        }

        if(currentHealth <= 0)
        {  
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        if(!isDead)
        {
            isDead = true;
            Invoke("Respawn", respawnDelay);
        }
        gameObject.GetComponent<Player_Move>().canMove = false;
        gameObject.GetComponent<Player_Shoot>().canShoot = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;


    }

    public void Respawn()
    {
        CheckpointManager.instance.LoadToLastCheckpoint();
        ScoreManager.instance.IncrementDeaths();
        currentHealth = maxHealth;
        gameObject.GetComponent<Player_Move>().canMove = true;
        gameObject.GetComponent<Player_Shoot>().canShoot = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        isDead = false;
    }

    public void DamagePlayer(float damage)
    {
        currentHealth -= damage;
    }
}
