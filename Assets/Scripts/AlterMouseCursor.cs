using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlterMouseCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private GameObject cursor;
    //private SpriteRenderer sp;
    private Vector3 offset;

    void Start()
    {
        cursor = new GameObject();
        cursor.transform.parent = gameObject.transform;
        float scale = 1.0f;
        cursor.transform.localScale = new Vector3(scale, scale, scale);
        cursor.transform.localPosition = Vector3.zero;

        Image NewImage = cursor.AddComponent<Image>();
        NewImage.sprite = Sprite.Create(cursorTexture, new Rect(0, 0, cursorTexture.width, cursorTexture.height), new Vector2(0, 0), 1);

       RectTransform tempRect = cursor.GetComponent<RectTransform>();

        offset = new Vector3(tempRect.rect.width/2, -20.0f, 0);

        //sp = cursor.AddComponent<SpriteRenderer>();
        //Sprite tempSprite = Sprite.Create(cursorTexture, new Rect(0, 0, cursorTexture.width, cursorTexture.height), new Vector2(0, 0), 1);
        //sp.sprite = tempSprite;
        //offset = new Vector3(cursorTexture.width / 2, cursorTexture.height / 2, 0.0f) * scale;
        //offset = new Vector3(-30.0f, -20.0f, 0.0f);
        //offset = Vector3.zero;
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) + offset;
        temp.z = 0.0f;
        cursor.transform.position = temp;
    }

    void OnDestroy()
    {
        //Cursor.SetCursor(null, Vector2.zero, cursorMode);
        Cursor.visible = true;
    }

    /*
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
    */
}
