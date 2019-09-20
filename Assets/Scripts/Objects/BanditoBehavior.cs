using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditoBehavior : MonoBehaviour
{
    /// <summary> Bandito can be killed from scalp. If true, cannot.</summary>
    public bool hatBandito;
    ///<summary> Bandito hat prefab</summary>
    public GameObject hat;

    /// <summary> Bandito can be killed from chin. If true, cannot.</summary>
    public bool maskBandito;
    ///<summary>Bandito mask prefab</summary>
    public GameObject mask;

    /// <summary> Distance this bandito moves.</summary>
    public float walkDistance;
    /// <summary> Speed at which this bandito moves.</summary>
    [Range(0,1)]
    public float walkSpeed;
    /// <summary> Ease through the walk.</summary>
    public bool walkLerp;
    /// <summary> Pause in between returning to origin point after moving.</summary>
    public float walkPause;
    /// <summary> Logic variable to control movement direction.</summary>
    private bool returnToOrigin;
    /// <summary> Logic variable to control stopping movement.</summary>
    private bool stop;

    /// <summary> Original point of the bandito.</summary>
    private Vector3 origin;

    /// <summary>Bandito's Rigidbody.</summary>
    private Rigidbody2D self;

    /// <summary>Blood spatter prefab.</summary>
    public GameObject bloodSpatter;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn hats/masks if necessary
        if (hatBandito) Instantiate(hat, transform, false);
        if (maskBandito) Instantiate(mask, transform, false);

        //Find original position before moving.
        origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        returnToOrigin = false;
        stop = false;

        //Find Rigidbody2D
        self = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkDistance != 0 && !stop) Movement();
    }

    void Movement()
    {
        if (returnToOrigin)
        //Move towards the origin point.
        {
            if (walkLerp)
            {
                Vector3 target = new Vector3(origin.x, origin.y, origin.z);
                transform.position = Vector3.Lerp(transform.position, target, walkSpeed * Time.deltaTime);
            } else
            {
                transform.Translate(new Vector3(-walkSpeed * Time.deltaTime, 0, 0));
            }
            
            //Check if you're at the origin
            if (Mathf.Abs(transform.position.x-origin.x) <= 0.1)
            {
                stop = true;
                Invoke("ChangeDirection", walkPause);
            }
        } else
        //Move towards the target point.
        {
            if (walkLerp)
            {
                Vector3 target = new Vector3(origin.x+walkDistance, origin.y, origin.z);
                transform.position = Vector3.Lerp(transform.position, target, walkSpeed*Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(walkSpeed*Time.deltaTime, 0, 0));
            }

            //Check if you're at the target
            if (Mathf.Abs(transform.position.x - origin.x) >= walkDistance-walkSpeed)
            {
                stop = true;
                Invoke("ChangeDirection", walkPause);
            }
        }
    }

    void ChangeDirection()
    {
        returnToOrigin = !returnToOrigin;
        stop = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.instance.PlaySound("Impact1");
            Instantiate(bloodSpatter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
