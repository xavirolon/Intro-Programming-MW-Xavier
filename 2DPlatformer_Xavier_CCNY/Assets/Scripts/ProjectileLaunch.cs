using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    // GLOBAL VARIABLES
    // this script is on the player, not on the launch point

    public GameObject projectilePreFab; // declare and set projectilePrefab game object
    public Transform launchPoint;   // position where the projectile will launch

    // cooldown timer stuff
    public float shootTime = 0.5f;  // cooldown time amount between the projectile firing
    public float shootCount;    // cooldown timer

    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        // if Left mouse button and the shootCount is reset to 0, or less than 0...
        if(Input.GetMouseButtonDown(0) && shootCount <= 0)
        {
            // instantiate projectile pre fab, at launch point
            // instantiate projectile prefab at the launch position, we are using Quaternion Identity for rotation
            Instantiate(projectilePreFab, launchPoint.position, Quaternion.identity);
            
            shootCount = shootTime; // reset cooldown time to prevent shooting
        }

        // reducing shootCount constantly over time
        shootCount -= Time.deltaTime;
    }


}
