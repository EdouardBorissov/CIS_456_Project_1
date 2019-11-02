using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Eddie B
 */
public class GatePlatformBehavior : TogglableObject
{
    private DeathFloorBehavior deathFloorScript;
    private SpriteRenderer spriteRenderer;
    private Collider2D objCollider;
    private bool isToggled = false;
    public override void Toggle()
    {
        if (isToggled)
        {
            isToggled = false;
            deathFloorScript.canKill = true;
            spriteRenderer.color = Color.red;
            objCollider.enabled = true;


        }
        else if (!isToggled)
        {
            isToggled = true;
            deathFloorScript.canKill = false;
            objCollider.enabled = false;
            spriteRenderer.color = new Color(1, 1, 1, .2f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        deathFloorScript = gameObject.GetComponent<DeathFloorBehavior>();
    }
}
