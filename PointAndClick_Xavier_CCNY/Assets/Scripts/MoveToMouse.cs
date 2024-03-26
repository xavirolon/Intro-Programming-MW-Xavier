using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    // MON 3/25
    // GLOBAL VARIABLES

    public float speed = 5f;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        // set target's value = transform.position the object is attached to
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // check if the mouse has been clicked
        if (Input.GetMouseButtonDown(0))
            // check if left mouse button (0) was clicked
        {
            Debug.Log("Click to move.");

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;    //set the target z-axis constanlty at 0
            // NOTE: can set target.z = 0 b/c we are not changing z-axis
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
