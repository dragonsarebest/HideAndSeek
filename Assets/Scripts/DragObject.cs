using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool selected = false;
    private Vector3 mOffSet;
    private float mZCoord;


    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet = gameObject.transform.position - getMousePos();
    }

    Vector3 getMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseDrag()
    {
        transform.position = getMousePos() + mOffSet;
    }
}
