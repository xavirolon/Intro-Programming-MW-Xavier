using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    // MON 3/25
    // GLOBAL VARIABLES
    private bool isDragging = false;    // if object dragging or not
    private Vector3 offset; //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // to move sprite, check if isDragging == True
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            // 
        }
    }

    // DRAG
    private void OnMouseDown()  // returns true if mouse is clicking on collider object
    {
        //Debug.Log("Mouse Down.");
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // set offset to the positon minus where we clicked in space

        
        isDragging = true;
        //Debug.Log("isDragging = " + isDragging);

        
    }

    private void OnMouseUp()    // true when user released mouse button
    {
        //Debug.Log("Mouse Up.");
        isDragging = false;
        //Debug.Log("isDragging = " + isDragging);
    }
}
