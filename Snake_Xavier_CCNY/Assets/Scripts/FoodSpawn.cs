using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    // GLOBAL VARIABLES
    public GameObject foodPreFab;

    // border positions
    public Transform wallTop;
    public Transform wallBottom;
    public Transform wallLeft;
    public Transform wallRight;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke("Spawn", 4);
        InvokeRepeating("Spawn", 3, 4);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        // Debug.Log("Spawn Called");
        
        int xPos = (int)Random.Range(wallLeft.position.x + 2, wallRight.position.x - 2);
        int yPos = (int)Random.Range(wallTop.position.y - 2, wallBottom.position.y + 2);

        Instantiate(foodPreFab, new Vector3(xPos, yPos, 0), Quaternion.identity);
    
    }
}
