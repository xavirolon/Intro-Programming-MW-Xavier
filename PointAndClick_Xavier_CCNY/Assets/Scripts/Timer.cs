using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //GLOBAL VARIABLES
    //Time variables
    public float timeRemaining = 90; //declare and set float variable to store the amount of time remaining
    public bool timerIsRunning = false; //declare and set bool variable for whether or not the timer is running

    //UI Elements
    public TextMeshProUGUI timeText; //Text Object for Time Text, set in inspector

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true; //Start timer by setting bool to true

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning) //If the timer is running...
        {
            if (timeRemaining > 0) //If there is time remaining...
            {
                timeRemaining -= Time.deltaTime; //subtract the duration of the prevous frame from time remaining
                                                 //deltaTime is the duration of the previous frame
            }
            else if (timeRemaining <= 0) //if there is 0 timeRemaining (Time has Run Out)
            {
                Debug.Log("time has run out!");  //print to console
                timeRemaining = 0; //lock timeRemaing to 0 so it doesn't go into negative numbers
                timerIsRunning = false; //set bool to false to stop timer
            }
            //Debug.Log("timeRemaining = " + timeRemaining);
        }
        DisplayTime(); //call DisplayTime()

    }
    //Display the timeRemaining through UI Text
    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60); //calculate minutes. Divide the timeRemaining by 60
                                                              //Mathf is a collection of common math functions, like division, multiplication, etc.
                                                              //FloorToInt rounds a float down to the nearest whole integer
        float seconds = Mathf.FloorToInt(timeRemaining % 60); //calculate seconds
                                                              //% = a Modulo operation. It returns a remainder int after a division
                                                              //For example, 62 % 60 returns a remainder of 2, which is our seconds value!

        //Debug.Log("minutes = " + minutes);
        //Debug.Log("seconds = " + seconds);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //change text displayed in timeText Text Object
                                                                          //string.Format lets you place variables inside a formatted string
                                                                          //in this case, we're using 2 double-digit numbers separated by a colon
                                                                          //Variable 0 = minutes, put into 00 formatting option
                                                                          //Variable 1 = seconds, put into 00 formatting option

    }
}