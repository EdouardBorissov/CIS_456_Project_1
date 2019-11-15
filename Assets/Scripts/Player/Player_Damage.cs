using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Damage : MonoBehaviour
{
    private float currentHealth;
    public float maxHealth = 100f;
    public Image healthBar;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            currentHealth -= 20;
            healthBar.fillAmount = currentHealth / maxHealth;
        }

        if(currentHealth <= 0)
        {
            ScoreManager.instance.IncrementDeaths();
            Destroy(player);
        }
    }
}
