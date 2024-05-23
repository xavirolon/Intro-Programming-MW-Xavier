using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalReached : MonoBehaviour
{
    // scipt lives on the end goal object at the end of a level
    // GLOBAL VARIABLES
    public int sceneID; // set the scene you want to go to
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // events when colliding with this trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player collides with the trigger...
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("End of Level");
            SceneManager.LoadScene(sceneID);    // load the next scene
        }
    }
}
