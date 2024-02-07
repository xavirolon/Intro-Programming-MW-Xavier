using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    // GLOBAL VARIABLES (Universal)
// variable naming convention: xPositionTall
// rigidbody2D gives physics components to objects (mass, gravity, force, etc)
    public Rigidbody2D rbBall;
    public float force = 200;

    private float xDir;
    private float yDir;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello, World!");
        Vector3 direction = new Vector3(0, 0, 0);

        xDir = Random.Range(0, 2);  // (0, 2) returns 0 or 1 only
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
        rbBall.AddForce(direction * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
