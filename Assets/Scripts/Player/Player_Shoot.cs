using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public Transform revolverMuzzle;
    public GameObject revolverBullet;

    private int loadedRevolverAmmo = 6;//The ammo currently loaded in the revolver.

    /// <summary>
    /// The amount of time before the Revolver Bullet is automatically destroyed
    /// </summary>
    public float revolverBulletLifeTime;

    public float revolverReloadTime;

    public float revolverBulletSpeed;

    /// <summary>
    /// The Revolver's rate of fire.
    /// </summary>
    public float revolverRof;

    public bool canShoot = true;
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
                firedBullet.GetComponent<Rigidbody2D>().velocity = firedBullet.transform.right * revolverBulletSpeed * Time.deltaTime;
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
