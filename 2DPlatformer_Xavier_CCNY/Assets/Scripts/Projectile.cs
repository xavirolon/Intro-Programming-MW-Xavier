using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // GLOBAL VARIABLES
    public Rigidbody2D projectileRb;    // get rigidbody of projectile
    public float speed = 4; // speed of the projectile

    // projectile countdown timer stuff
    public float projectileLife = 2; // after 2 seconds, projectile destroys itself
    public float projectileCount;   // counts down time until projectile destroys itself, currently 0

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
        // want to reduce projectileCount with each second
        projectileCount -= Time.deltaTime;

        // if projectile count runs out
        if(projectileCount <= 0)
        {
            Destroy(gameObject);    // destroy the game object, the projectile 
        }
    }

    // FixedUpdate is called every fixed framerate frame
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
        // we are shooting according to the value of our Vector3
        
    
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
       {
            // Debug.Log("Projectile hit Rock");
            Destroy(collision.gameObject);  // destroy the object we collided with

            Destroy(gameObject);    // destroy the projectile when it hits something as well
       }
       Destroy(gameObject); // also destroy the projectile
    }

}
