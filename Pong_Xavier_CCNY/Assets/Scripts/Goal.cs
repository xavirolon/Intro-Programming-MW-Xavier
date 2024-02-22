using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // GLOBAL VARIABLES
    public bool isPlayer1Goal;
    public GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tag is different than name....
        // looking for something with a tag
        if (collision.gameObject.tag == "Ball")
        {
            // Debug.Log("Ball in Trigger");
            if (isPlayer1Goal)  // player 1 got scored on
            {
                myManager.Player2Scored();
            }
            else    // player 2 got scored on
            {
                myManager.Player1Scored();
            }
        }
    }
}
