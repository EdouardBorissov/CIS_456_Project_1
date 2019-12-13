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
    public List<GameObject> gibs;
    public Transform gibSpawnLocation;
    // public Image healthBar;
    public List<SpriteRenderer> visibleElements;
    private Collider2D playerCollider;
    public List<ParticleSystem> bloodParticles;


    // Start is called before the first frame update
    void Start()
    {  
        playerCollider = gameObject.GetComponent<Collider2D>();
        currentHealth = maxHealth;
       // healthBar.fillAmount = 1.0f;
    }



    // Update is called once per frame
    void Update()
    { 
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
            foreach (GameObject gib in gibs)
            {
                GameObject spawnedGib = Instantiate(gib, transform.position, transform.rotation);
            }
            foreach (ParticleSystem blood in bloodParticles)
            {
                blood.Play();
            }
        }

        playerCollider.enabled = false;

        foreach (SpriteRenderer sprite in visibleElements)
        {
            sprite.enabled = false;
        }



        gameObject.GetComponent<Player_Move>().canMove = false;
        gameObject.GetComponent<Player_Shoot>().canShoot = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);


    }

    public void Respawn()
    {
        playerCollider.enabled = true;

        foreach (SpriteRenderer sprite in visibleElements)
        {
            sprite.enabled = true;
        }
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
