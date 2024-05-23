using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeepMe : MonoBehaviour
{
    // GLOBAL VARIABLES

    public static GameObject instance;  // static variable to preserve its value when not in loaded scene


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called once when the script instance is loaded
    private void Awake()
    {
        // when the new scene/instance of this script loads...
        if (instance == null)   // if no value
        {
            Debug.Log("Audio Manager not destroyed");
            instance = gameObject;  // set value of instance to game object this script is attached to
            DontDestroyOnLoad(gameObject);  // do not destroy the target object
        }
        else    // otherwise if the instance does already exist in the scene
        {
            Debug.Log("Extra Audio Manager Destroyed");
            Destroy(gameObject);    // destroy the duplicate object in the new scene
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
