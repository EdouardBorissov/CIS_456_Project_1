using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
  * Eddie Borissov
  * CIS_456
  * Project 2
  * 
  * Code meant to enable and disable the bullet gameobjects in the Ammo UI, showing the 
  * player how many bullets they currently have.
  * Also rotates the cylinder while reloading.
  * 
  */
public class PlayerUI_Ammo : MonoBehaviour
{
    private int bulletsFired = 0;
    public List<GameObject> ui_Bullets;
    public Image cylinder;
    public float rotateAmount;
    public float rotateFrequency;


    public void ShootBullet()
    {
        ui_Bullets[bulletsFired].SetActive(false);
        //cylinder.rectTransform.Rotate(0, 0, -60);
        bulletsFired++;
    }

    public void ReloadBullets()
    {
        SoundManager.instance.PlaySound("Reload");

        InvokeRepeating("RotateCylinder", 0, rotateFrequency);
        bulletsFired = 0;
        foreach(GameObject gameObj in ui_Bullets)
        {
            gameObj.SetActive(true);
        }
    }

    public void StopRotatingCylinder()
    {
        SoundManager.instance.StopSound("Reload");

        CancelInvoke("RotateCylinder");
        cylinder.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void RotateCylinder()
    {
        cylinder.rectTransform.Rotate(0, 0, rotateAmount);
    }

}
