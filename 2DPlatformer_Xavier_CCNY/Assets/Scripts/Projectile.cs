using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Wednesday 4/10
    // GLOBAL VARIABLES
    public Rigidbody2D projectileRb;    // get rigidbody of projectile
    public float speed = 5;

    // projectile countdown timer stuff
    public float projectileLife = 2; // after 2 seconds, projectile destroys itself
    public float projectileCount;

    // flip launch direction
    public PlayerController playerControllerScript;
    public bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;

        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        facingLeft = playerControllerScript.facingLeft;

        if (!facingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        // want to reduce projectileCount
        projectileCount -= Time.deltaTime;

        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!facingLeft) // if we are facing right
        {
            projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0);
        }
        else
        {
            projectileRb.velocity = new Vector3(-speed, projectileRb.velocity.y, 0);
        }
        // could also switch the values of speed and leave if(facingLeft) as is
        
        
    
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Lava")
        {
            // Debug.Log("Projectile hit Rock");
            Destroy(collision.gameObject);  // destory the object we collided with

            Destroy(gameObject);    // destroy the projectile when it hits something as well
        }    
    }
}
