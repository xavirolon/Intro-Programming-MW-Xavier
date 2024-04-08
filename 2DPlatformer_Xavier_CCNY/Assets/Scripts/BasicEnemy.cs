using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Mon 4/8
    // GLOBAL VARIABLES
    public int damage;
    public PlayerController playerControllerScript;

    // enemy movement
    public Transform[] patrolPoints;
    public float moveSpeed = 3;
    public int patrolDestination;   // similar to patrol points


    // Start is called before the first frame update
    void Start()
    {
        damage = 5;


    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Debug.Log("Hit");
            playerControllerScript.TakeDamage(damage);

        }
    }

    private void EnemyMovement()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5)
            {
                patrolDestination = 1;
            }
        }

        if (patrolDestination == 1)
        {
            //Debug.Log("change direction");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5)
            {
                patrolDestination = 0;
            }
        }
        
    }
}
