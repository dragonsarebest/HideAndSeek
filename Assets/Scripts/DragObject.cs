using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffSet;
    private float mZCoord;

    private Vector3 initalLocation;

    void Start()
    {
        initalLocation = transform.position;
    }

    void OnMouseDown()
    {
        //Debug.Log("Down");
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet = gameObject.transform.position - getMousePos();
    }

    void OnMouseUp()
    {
        //Debug.Log("Up");

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
        //Debug.Log("Drag");
        transform.position = getMousePos() + mOffSet;
    }
}
