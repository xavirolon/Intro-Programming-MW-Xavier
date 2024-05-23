using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class BasicEnemy : MonoBehaviour
{
    // GLOBAL VARIABLES
    public int damage;  // damage variable
    public PlayerController playerControllerScript; // refer to Player Controller script

    // enemy movement
    public Transform[] patrolPoints;    // set a Transform variable as an array
    public float moveSpeed = 3; // movement speed
    public int patrolDestination;   // similar to patrol points

    public bool flippedLeft;    // tracking which way enemy is facing
    public bool facingLeft; // tracking which way enemy should be facing

    // Start is called before the first frame update
    void Start()
    {
        damage = 5; // damage value set in Start


    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();    // call the enemie's movement
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when enemy collides with a player
        if(collision.gameObject.tag == "Player")
        {
            // Debug.Log("Hit");
            // call and set TakeDamage(int) to damage value from Player Controller script
            playerControllerScript.TakeDamage(damage);  // give int value of damage

        }
    }

    private void EnemyMovement()
    {
        if (patrolDestination == 0) // if patrolDestination is 0...
        {
            // move to patrol Destination 0
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            facingLeft = true;  // enemy is facing/moving to the left
            

            // if enemy has 'reached' patrol point
            // if the distance between the two objects is < 0.2f
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5)
            {
                patrolDestination = 1;  // set patrol destination to 1 in the array
                EnemyFlip(facingLeft);  // call EnemyFlip and give the bool
            }
        }

        // if patrol Destination is 1..
        if (patrolDestination == 1)
        {
            //Debug.Log("change direction");
            // move to patrol Destination 1
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            facingLeft = false;  // enemy moving right
            

            // if enemy has 'reached' patrol point
            // if distance between two objects is < 0.2f
            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5)
            {
                patrolDestination = 0;  // set patrol destination to 0 in the array
                EnemyFlip(facingLeft);  // call EnemFlip and give the bool
            }

        }
        
    }
    void EnemyFlip(bool facingLeft)
    {
        // Debug.Log("EnemyFlip() called, facingLeft = " + facingLeft);
        // if the enemy is facing left but is flipped right
        if(facingLeft && !flippedLeft)
        {
            transform.Rotate(0, -180, 0);   // flip the sprite
            flippedLeft = true;
        }
        // if enemy is not facing left but is flipped right
        if (!facingLeft && flippedLeft)
        {
            transform.Rotate(0, -180, 0);   // flip the sprite
            flippedLeft= false;
        }
    }
}
