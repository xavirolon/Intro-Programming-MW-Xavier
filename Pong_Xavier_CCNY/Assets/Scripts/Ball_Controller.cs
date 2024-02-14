using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    // GLOBAL VARIABLES (Universal)
// variable naming convention: xPositionTall

// rigidbody2D gives physics components to objects (mass, gravity, force, etc)
    public Rigidbody2D rbBall;
    public float force = 200; // declare and set force variable

    private float xDir; // declare x direction float
    private float yDir; // declare y direction float

    public bool inPlay;
    public Vector3 ballStartPos;

    // Start is called before the first frame update
    void Start()
    {
        // this is a comment
        // Debug.Log("Hello, World!"); // print to console
        
        Launch();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlay == false)
        {
            transform.position = ballStartPos;
            Launch();
        }
    }
    

    void Launch()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        // Set direction.x (which way the ball moves horizontally)
        xDir = Random.Range(0, 2);  // pick a random int between 0 and 1
        // Debug.Log("xDir = " + xDir);
        if (xDir == 0)
        {
            direction.x = -1;   // moves left
        }
        else if (xDir == 1)
        {
            direction.x = 1;    // move right
        }
        
        yDir = Random.Range(0, 2);
        if (yDir == 0)
        {
            direction.y = -1;   // move down
        }
        else if (yDir == 1)
        {
            direction.y = 1;    // move up
        }

        // add force to start movement
        rbBall.AddForce(direction * force); // launch the ball
        inPlay = true;
    }

    // EVENTS UPON COLLISION
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("object that collided w/ Ball: " + collision.gameObject.name);
        if (collision.gameObject.name == "Left Wall" || collision.gameObject.name == "Right Wall")
        {
            // Debug.Log("collided with Left/Right Wall");
            rbBall.velocity = Vector3.zero;
            inPlay = false;
        }
    }
}
