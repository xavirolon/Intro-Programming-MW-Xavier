using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // scene manager

public class SceneChanger : MonoBehaviour
{
    // GLOBAL VARIABLES
    public int sceneNumber; // two scenes, main menu, game
    public Snake snake; // access snake script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovetoScene()
    {
        SceneManager.LoadScene("MainScene");    // load game screen when button is pressed

        // when button is pressed, snake immediately starts moving
        

    }
}
