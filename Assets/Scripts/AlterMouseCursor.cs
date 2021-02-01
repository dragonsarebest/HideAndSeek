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
    private Canvas canvas;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvas = gameObject.GetComponent<Canvas>();
        //canvas.worldCamera = Camera.main;

        cursor = new GameObject();
        cursor.transform.parent = gameObject.transform;
        float scale = 0.002f;
        cursor.transform.localScale = new Vector3(scale, scale, scale);
        cursor.transform.localPosition = Vector3.zero;

        SpriteRenderer NewImage = cursor.AddComponent<SpriteRenderer>();
        NewImage.sprite = Sprite.Create(cursorTexture, new Rect(0, 0, cursorTexture.width, cursorTexture.height), new Vector2(0, 0), 1);

        RectTransform tempRect = cursor.AddComponent<RectTransform>();
        //RectTransform tempRect = cursor.GetComponent<RectTransform>();

        offset = new Vector3(0.0f, -46.0f, 0.0f);

        //we also need to alter the mouse pos by the current gameobj pos

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
        //Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) + offset;
        //temp.z = -12.0f;
        ////temp = Vector3.zero;
        //cursor.transform.position = temp;

        cursor.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8.0f)+ offset);
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
    /*
    public Vector2 ScreenToRectPos(Vector2 screen_pos)
    {
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && canvas.worldCamera != null)
        {
            //Canvas is in Camera mode
            Vector2 anchorPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screen_pos, canvas.worldCamera, out anchorPos);
            return anchorPos;
        }
        else
        {
            //Canvas is in Overlay mode
            Vector2 anchorPos = screen_pos - new Vector2(rectTransform.position.x, rectTransform.position.y);
            anchorPos = new Vector2(anchorPos.x / rectTransform.lossyScale.x, anchorPos.y / rectTransform.lossyScale.y);
            return anchorPos;
        }
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
    */
}
