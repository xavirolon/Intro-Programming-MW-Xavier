using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    // Wednesday 4/10
    // GLOBAL VARIABLES
    public GameObject projectilePreFab;
    public Transform launchPoint;

    // cooldown timer stuff
    public float shootTime = 0.5f;
    public float shootCount;

    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && shootCount <= 0)
        {
            // instantiate projectile pre fab, at launch point
            Instantiate(projectilePreFab, launchPoint.position, Quaternion.identity);
            shootCount = shootTime;
        }

        // reducing shootCount constantly over time
        shootCount -= Time.deltaTime;
    }


}
