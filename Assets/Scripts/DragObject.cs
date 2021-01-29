using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffSet;
    private float mZCoord;

    private Vector3 initalLocation;
    public bool DEBUG = false;

    void Start()
    {
        initalLocation = transform.position;
    }

    void OnMouseDown()
    {
        if(DEBUG)
            Debug.Log("Down");
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet = gameObject.transform.position - getMousePos();
    }

    void OnMouseUp()
    {
        if (DEBUG)
            Debug.Log("Up");

        if (!GetComponent<Renderer>().isVisible)
        {
            transform.position = initalLocation;
        }
    }


    Vector3 getMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseDrag()
    {
        if (DEBUG)
            Debug.Log("Drag");
        transform.position = getMousePos() + mOffSet;
    }
}
