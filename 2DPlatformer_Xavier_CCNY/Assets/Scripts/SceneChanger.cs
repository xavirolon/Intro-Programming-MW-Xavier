using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // script lives on Game Manager

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToScene(int sceneID)
    {
        // SceneManager.LoadScene("EndScene"); // call a scene specifically by number
        SceneManager.LoadScene(sceneID);    // load scene based off sceneID
    }

}
