using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // allows use of lists
using UnityEngine.SceneManagement;
using TMPro;

public class Snake : MonoBehaviour
{
    // GLOBAL VARIABLES
    Vector3 dir = Vector3.right;
    public Vector3 snakeStartPos;
    public bool gameOver;   // variable for when game is running
    public FoodSpawn foodSpawn; // access FoodSpawn script

    public SceneChanger sceneChange; // access SceneChanger script
    public TextMeshProUGUI foodScoreText;

    // Keep Track of Tail Elements
    List<Transform> tail = new List<Transform>();
    bool ate = false; 
    public GameObject tailPreFab;

    // call GameManager script to use in this script
    public GameManager myManager;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

        // Change the snake's direction by calling function
        ChangeDirection();

        // Free work Wednesday 
         if(gameOver == true)   // when the game is over
        {

            // if game over, rreset position of snake
            transform.position = snakeStartPos;
            Vector3 dir = new Vector3(0, 0, 0);
            gameOver = false;   // game over set to false...replay
            myManager.foodScore = 0;    // resest score

        }
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

            // change score
            myManager.FoodEaten();
        }

        // can give walls tags and make a game over function
        if (collision.gameObject.tag == "Wall")
        {
            gameOver = true;    // snake died on wall
            SceneManager.LoadScene("GameOver"); // load game over scene when snake hits wall (dead)
            

            // destroy all "Food" tagged objects
            // Destroy(gameObject.tag == "Food");

            // destroy all tail segments
            foreach (Transform segment in tail)
            {
                Destroy(segment.gameObject);    // destroy all segments of snake
            }
            tail.Clear();   // clear list of tails
        }
    }
}
