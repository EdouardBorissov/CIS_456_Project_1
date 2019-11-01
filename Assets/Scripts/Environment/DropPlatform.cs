using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : TogglableObject
{
    private DeathFloorBehavior deathFloorScript;
    private SpriteRenderer spriteRenderer;
    private bool isToggled = false;

    public override void Toggle()
    {
        if(isToggled)
        {
            isToggled = false;
            deathFloorScript.canKill = true;
            spriteRenderer.color = Color.red;
        }
        else if(!isToggled)
        {
            isToggled = true;
            deathFloorScript.canKill = false;
            spriteRenderer.color = Color.green;
        }
        Debug.Log(gameObject.name + " was toggled");
    }

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        deathFloorScript = gameObject.GetComponent<DeathFloorBehavior>();
    }

}
