using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // access to text mesh pro ui library

public class GameManager : MonoBehaviour
{
    // GLOBAL VARIABLES
    // game objects for UI Elements
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    // SCORES
    private int player1Score = 0;
    private int player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // every time score changes, 'update' it
        player1ScoreText.text = "P1: " + player1Score;
        player2ScoreText.text = "P2: " + player2Score;
    }

    // not going to be called from anywhere in this script
    // will bbe called inside the 'Goal' script
    public void Player1Scored()
    {
        player1Score++;
    }

    public void Player2Scored()
    {
        player2Score++;
    }
}
