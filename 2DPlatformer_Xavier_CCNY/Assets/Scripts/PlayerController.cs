using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // M/W 4/1
    // GLOBAL VARIABLES
    public Rigidbody2D playerBody;

    public float playerSpeed = 0.5f;    // 0.05f; 
    public float jumpForce = 300;
    public bool isJumping = false;

    // 4/3 new global variables
    // player health
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBarScript;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);
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
            newPos.x -= playerSpeed;    // every frame subtract speed
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D Pressed.");
            newPos.x += playerSpeed;
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
        if(collision.gameObject.tag == "Surface")
        {
            isJumping = false;
        }

        if(collision.gameObject.tag == "Lava")
        {
            // Debug.Log("Ow.");
            TakeDamage(2);

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarScript.SetHealth(currentHealth);
    }
}
