using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // GLOBAL VARIABLES
    public Rigidbody2D playerBody;  // rigidbody variable for player

    public float playerSpeed = 1f;    // 0.05f; // setting player speed 
    public float jumpForce = 375;   // player jumpforce 
    public bool isJumping = false;  // set a bool to determine if we are jumping

    // player health
    public int maxHealth = 20;  // maxHealth variable
    public int currentHealth;   // declare player's current Health, this one changes
    public HealthBar healthBarScript;   // refer to HealthBar script

    // Flip Dirction variables
    public bool flippedLeft;    // keep track of which way sprite IS CURRENTLY FACING
    public bool facingLeft;    // keep track of which way our sprite SHOULD BE facing

    // sound effects
    public AudioSource lavaRockAudio;   // Audio Source component variable for lava rock 
    public AudioSource enemyAudio;  // Audio Source component variable for enemies

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  // set currentHealth to maxHealth when we start
        healthBarScript.SetMaxHealth(maxHealth);    // set integer of maxHealth to maxHealth value of this script
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }


    private void MovePlayer()
    {   
        // set to position of object attached to
        Vector3 newPos = transform.position;

        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A pressed");
            newPos.x -= playerSpeed;    // every frame subtract speed, moving left
            facingLeft = true;  // we are now facing left
            Flip(facingLeft);   // Flip() and put in the bool value
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D Pressed.");
            newPos.x += playerSpeed;    // moving right
            facingLeft = false; // we are facing right
            Flip(facingLeft);   // Flip() and put in bool value
        }

        // actually moving by setting the position the newPos varible
        transform.position = newPos;
    
    
    }

    private void Jump()
    {
        // GetKey applies force to every frame (shoots straight up so fast)
        // GetKeyDown fixes the issue, but now we can jump multiple times as well,
        // we want to avoid that

        // to prevent double jumping:
        // if(!isJumping && Input.GetKeyDown(KeyCode.Space))
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0));
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when touching the 'ground'
        if(collision.gameObject.tag == "Surface")
        {
            isJumping = false;
        }

        // if we touched a bad object
        if(collision.gameObject.tag == "Obstacle")
        {
            // Debug.Log("Ow.");
            TakeDamage(2);  // reduce health by 2
            lavaRockAudio.Play();   // play lava audio
        }

        // if we touch an enemy
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(3);  // reduce health by 5
            enemyAudio.Play();  // play enemy audio
        }    
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;    // reduce health by the damage variable amount
        healthBarScript.SetHealth(currentHealth);   // set SetHealth(int) to the currentHealth
    }

    public void Flip(bool facingLeft)
    {
        //Debug.Log("Flip() called, facingRight = " + facingRight);
        // if player is facing left but flipped right...
        if (facingLeft && !flippedLeft)
        {
            transform.Rotate(0, -180, 0);   // flip sprite

            flippedLeft = true;
        }
        // if player is facing right but flipped left...
        if (!facingLeft && flippedLeft)
        {
            transform.Rotate(0, -180, 0);   // flip sprite

            flippedLeft = false;
        }
    }


    // loading the End Scene
    void GameOver()
    {
        // if we run out of health..
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(2);  // load the end scene based off SceneID
        }
    }
}
