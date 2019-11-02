using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Edouard Borissov
 CIS_456_Project_1

    This script rotates the player's arm object, which allows bullets to be shot through the gun/arm's transform.forward.
    The script also flips the arm and player scripts to keep them from looking strange.
     
     
     
     */
public class Player_Aim : MonoBehaviour
{
    private Vector2 directionFacing;
    public int hasFlipped = 1;
    public bool canRotate = true;
    private Vector2 mouseCoordinates;
    public Transform playerTransform;

    private Rigidbody2D _rb;
    



    private LineRenderer gunToImpactRenderer;

    private LineRenderer ricochetRenderer;

    public GameObject revolverMuzzle;

    public float RendererDistance;

    private Vector3[] positionArray = new Vector3[2];
    private Vector3[] ricochetPositionArray = new Vector3[2];

     private void Awake() 
    {


        //add a linerenderer to the player's arm
    gunToImpactRenderer = gameObject.AddComponent<LineRenderer>();
    gunToImpactRenderer.startWidth = 0.2f;
    _rb     = GetComponent<Rigidbody2D>();

    }

    private void Start() 
    {

        
   gunToImpactRenderer.positionCount = 2;


        //ricochetRenderer = new LineRenderer();
    }


    void Update()

    {
        

        if (canRotate) //Might not be necessary, figured maybe you can't rotate while reloading the revolver?
        {
            RotateToMouse();
        }
        else
        {
            directionFacing = new Vector2(hasFlipped, 0f);
            transform.right = directionFacing;
        }

    }

     private void FixedUpdate() 
     {

        SetMouseCoordinates();
       
        CurrentDirectionFacing();

        DrawRicochetRenderer();
    }


    private void DrawRicochetRenderer()
    {
        //the linerenderer will always start at the muzzle
        positionArray[0] = revolverMuzzle.transform.position;

        //raycast from the muzzle outwards
        RaycastHit2D hit = Physics2D.Raycast(revolverMuzzle.transform.position, revolverMuzzle.transform.right * 150f);

        //if it hits something that's not a bullet the second point of the linerenderer 
        if (hit.collider != null)
        {        
            if (hit.collider.tag != "Bullet")
            {
                 positionArray[1] = hit.point;
            }
        }

        //otherwise, just go extend the linerenderer from the barrel
        else 
        {
            positionArray[1] = revolverMuzzle.transform.right * 150f;
        }


         gunToImpactRenderer.SetPositions(positionArray);
    }

    public void RotateToMouse()
    {
        Vector3 mouseLocation = Input.mousePosition;
        mouseLocation = Camera.main.ScreenToWorldPoint(mouseLocation);
        directionFacing = new Vector2(mouseLocation.x - transform.position.x, mouseLocation.y - transform.position.y);
        transform.right = GetMouseCoordinates();
    }




    public void CurrentDirectionFacing()
    {
        Vector3 flip = transform.localScale;
        Vector3 playerFlip = playerTransform.transform.localScale;
        if (GetMouseCoordinates().x < 0 && hasFlipped == 1)//turnLeft
        {
            flip.x *= -1;
            flip.y *= -1;
            playerFlip.x *= -1;
            transform.localScale = flip;
            playerTransform.localScale = playerFlip;
            hasFlipped *= -1;
           // CameraManager.instance.xOffset *= -1;
        }
        else if (GetMouseCoordinates().x > 0 && hasFlipped == -1)//turnRight
        {
            flip.x *= -1;
            flip.y *= -1;
            playerFlip.x *= -1;
            transform.localScale = flip;
            playerTransform.localScale = playerFlip;
            hasFlipped *= -1;
           // CameraManager.instance.xOffset *= -1;
        }
    }



    public Vector2 GetMouseCoordinates() //Not necessary inside this script, but could be useful elsewhere.
    {
        return mouseCoordinates;
    }
    public void SetMouseCoordinates()//Gives "mouseCoordinates" a value
    {
        Vector2 mouseLocation = Input.mousePosition;
        mouseLocation = Camera.main.ScreenToWorldPoint(mouseLocation);
        mouseCoordinates = new Vector2(mouseLocation.x - transform.position.x, mouseLocation.y - transform.position.y);
        //Very similar to RotateToMouse, except this doesn't actually rotate the player, just gets the mouse coordinates.
    }
}
