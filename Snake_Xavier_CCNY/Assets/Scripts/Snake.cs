using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // GLOBAL VARIABLES
    Vector3 dir = Vector3.right;
    public Vector3 snakeStartPos;
    public bool gameOver;
    public FoodSpawn foodSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();

        if(gameOver == true)
        {
            transform.position = snakeStartPos;
            Vector3 dir = new Vector3(0, 0, 0);
            gameOver = false;

            Destroy(foodSpawn);
        }
    }

    void MoveSnake()
    {
        transform.Translate(dir);
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
            // Debug.Log("Food Eaten");
            Destroy(collision.gameObject);  // destory the specific object that entered trigger
        }

        // can give walls tags and make a game over function
        if(collision.gameObject.tag == "Wall")
        {
            gameOver = true;
            Debug.Log("Game Over");
            
        }
    }
}
