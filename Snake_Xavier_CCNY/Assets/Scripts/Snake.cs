using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // allows use of lists

public class Snake : MonoBehaviour
{
    // GLOBAL VARIABLES
    Vector3 dir = Vector3.right;
    public Vector3 snakeStartPos;
    /*public bool gameOver;
    public FoodSpawn foodSpawn;*/


    // Keep Track of Tail Elements
    List<Transform> tail = new List<Transform>();
    bool ate = false; 
    public GameObject tailPreFab;




    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

        // Change the snake's direction by calling function
        ChangeDirection();

        /* Free work Wednesday 
         * if(gameOver == true)
        {
            transform.position = snakeStartPos;
            Vector3 dir = new Vector3(0, 0, 0);
            gameOver = false;

            Destroy(foodSpawn);
        }*/
    }

    void MoveSnake()
    {
        Vector3 gap = transform.position;


        // in snake, the snake is ALWAYS moving in one direction
        // move snake head in a direction
        transform.Translate(dir);

        if (ate)
        {
            // Debug.Log("ate = " + ate);
            // snake ate food...want to declare and set a variable immediately
            GameObject tailSec = (GameObject)Instantiate(tailPreFab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform);

            ate = false;
        }

        // check if snake has a tail
        else if (tail.Count > 0)
        {
            // move last tail element to where the head previously was
            tail.Last().position = gap;

            // keep our tail list in order:
            // Add last tail element to front of list and remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector3.right;
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector3.up;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector3.down;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            ate = true;

            // Debug.Log("Food Eaten");
            Destroy(collision.gameObject);  // destory the specific object that entered trigger
        
        }

        // can give walls tags and make a game over function
        /*if(collision.gameObject.tag == "Wall")
        {
            gameOver = true;
            Debug.Log("Game Over");
            
        }*/
    }
}
