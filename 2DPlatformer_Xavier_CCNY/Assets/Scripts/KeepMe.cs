using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeepMe : MonoBehaviour
{
    // 5/6 Monday class
    // GLOBAL VARIABLES

    public static GameObject instance;


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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Extra Audio Manager Destroyed");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
