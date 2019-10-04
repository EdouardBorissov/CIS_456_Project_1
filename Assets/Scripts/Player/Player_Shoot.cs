using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Edouard Borissov
    CIS_456_Project_1

    This script handles the revolver's behavior. Included below are rate of fire, reload, and shooting functions.
    Bullet behaviors, excluding bullet speed, are handled externally. Speed is handled internally for testing purposes, as
    bullet behavior scripts have not been made yet.    
     */

public class Player_Shoot : MonoBehaviour
{
    [Tooltip("Where the bullet is spawned")] public Transform revolverMuzzle;

    [Tooltip("The bullet.")] public GameObject revolverBullet;

    private int loadedRevolverAmmo = 6;//The ammo currently loaded in the revolver.

    
    [Tooltip("The amount of time before the Revolver Bullet is automatically destroyed")] public float revolverBulletLifeTime;

    [Tooltip("How long it takes to reload")] public float revolverReloadTime; //replace this later with a function called at the end of an animation

    [Tooltip("")] public float revolverBulletSpeed;

    [Tooltip("The Revolver's rate of fire.")] public float revolverRof;

    [Tooltip("A bool to be used externally.")] public bool canShoot = true; //Put this here if we want other scripts to stop the player from shooting. 
    private bool canFireRevolver = true;//Used for rate of fire.

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("ReloadRevolver", revolverReloadTime);
        }
    }

    private void Shoot()
    {
        if (canFireRevolver)//Checks if the Revolver is Equipped and can be fired.
        {
            if (loadedRevolverAmmo > 0) // If the gun has loaded ammo.
            {
                canFireRevolver = false;//prevents the Revolver from firing until the Rate of Fire is over.
                Invoke("RevolverCanFire", revolverRof);//Allows the Revolver to be fired after (revolverRoF) seconds.
                loadedRevolverAmmo--;
                GameObject firedBullet = Instantiate(revolverBullet, revolverMuzzle.transform.position, revolverMuzzle.transform.rotation);//Spawns bullet.
                SoundManager.instance.PlaySound("Gunshot");
                firedBullet.GetComponent<Rigidbody2D>().velocity = revolverMuzzle.transform.right * revolverBulletSpeed * Time.deltaTime;

                firedBullet.GetComponent<BulletScript>().SetBulletSpeed(revolverBulletSpeed);
               Destroy(firedBullet, revolverBulletLifeTime);
                if (loadedRevolverAmmo <= 0) // If the player tries to shoot, auto-reload.
                {
                   Invoke("ReloadRevolver", revolverReloadTime);
                   canFireRevolver = false;
                }
            }

        }
    }

    public void ReloadRevolver()
    {       
            for (int i = 6; i > 0; i--)//tries to put six bullets in
            {
                if (loadedRevolverAmmo < 6) //makes sure u have bullets to take, and slots to put them in
                {  
                    loadedRevolverAmmo++;
                }
            else
            {
                RevolverCanFire();
            }
            }
    }

    public void RevolverCanFire()
    {
        canFireRevolver = true;
    }


}
