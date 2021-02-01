using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeStudent : MonoBehaviour
{
    private Color start;
    private Color current;
    //public GameObject obj;
    private FreeDraw.DrawingSettings drawSurf;
    private Texture2D tex;

    public float FailThreshold = 60.0f;
    public bool erase = false;
    public Color drawColor = new Color(255f, 0f, 0f, 255f);
    public Color eraseColor = new Color(255f, 255f, 255f, 0f);

    private GameObject container;
    public TextMesh displayText;
    private BoxCollider2D collide;
    private GameObject DrawingArea;
    private GameObject parentObj;
    private Vector2 offsetVector;
    private Vector2 ogPaperSize;
    private int initalX, initalY, width, height;

    public float fontSize = 0.18f;

    public bool failed = false;

    public void setText(string text, GameObject DrawingArea2, GameObject parentGameObj)
    {
        parentObj = parentGameObj;
        DrawingArea = DrawingArea2; //new
        container = new GameObject();
        container.transform.parent = gameObject.transform;
        
        //Debug.Log(text);
        displayText = container.AddComponent<TextMesh>();
        displayText.text = text;
        displayText.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        float scale = fontSize * parentGameObj.transform.localScale.x;
        container.transform.localScale = new Vector3(scale, scale, scale);
        container.transform.localPosition = Vector3.zero;


        collide = container.AddComponent<BoxCollider2D>();

        Bounds textBounds = displayText.GetComponent<Renderer>().bounds;

        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
        box.size = new Vector2(collide.size.x * container.transform.localScale.x, collide.size.y * container.transform.localScale.y);
        box.offset = new Vector2(collide.offset.x * container.transform.localScale.x, collide.offset.y * container.transform.localScale.y);

        collide.enabled = false;
        collide = gameObject.GetComponent<BoxCollider2D>();

        Texture TempTex = parentObj.GetComponent<SpriteRenderer>().sprite.texture;
        ogPaperSize = 0.5f * new Vector2(TempTex.width, TempTex.height);
        offsetVector = new Vector2(parentObj.transform.position.x, parentObj.transform.position.y) - ogPaperSize;
    }

    void Start()
    {
        tex = DrawingArea.GetComponent<SpriteRenderer>().sprite.texture;
        //Debug.Log(tex.height);
        //Debug.Log(tex.width);

        //Debug.Log(obj);
        initalX = (int)(100 * (gameObject.transform.localPosition.x) - offsetVector.x - 0.5 * collide.size.x);
        //add 1/2 width of image to get it to be centered @ top left corner

        initalY = (-1 * (int)(100 * (gameObject.transform.localPosition.y) + offsetVector.y - 0.5 * collide.size.y));
        //Debug.Log("Y: " + initalY.ToString());
        //subtact 1/2 length of image to get it to be centered @ top left corner
        width = (int)(100 * collide.size.x);
        height = (int)(100 * collide.size.y);

        //tex = DrawingArea.GetComponent<SpriteRenderer>().sprite.texture.SubTexture(new Rect(initalX, initalY, width, height));

        //tex = new Texture2D(width, height);
        //Texture2D SrcText = DrawingArea.GetComponent<SpriteRenderer>().sprite.texture;
        //Graphics.CopyTexture(SrcText, 0, 0, initalX, initalY, width, height, tex, 0, 0, 0, 0);
        //tex.Apply();
        //SrcText.Apply();


        drawSurf = DrawingArea.GetComponent<FreeDraw.DrawingSettings>();
        //Debug.Log(tex);
        start = AverageColor(tex, initalX, initalY, width, height);
    }

    // Update is called once per frame
    void Update()
    {
        offsetVector = - ogPaperSize;
        //new Vector2(parentObj.transform.position.x, parentObj.transform.position.y) - ogPaperSize;
        //Debug.Log(offsetVector);
        if(!failed)
            current = AverageColor(tex, initalX, initalY, width, height);
        //Debug.Log(current);
        //Debug.Log(start);

        if(current.r >= FailThreshold && !failed)
        {
            Debug.Log("YOU FAIELD");
            failed = true;
        }
    }

    void changePen()
    {
        if (erase)
        {
            drawSurf.SetMarkerColour(eraseColor);
        }
        else
        {
            drawSurf.SetMarkerColour(drawColor);
        }
    }

    Color AverageColor(Texture2D tex, int startX, int startY, int width, int height)
    {
        /*
        var texColors = tex.GetRawTextureData<Color32>();
        tex.Apply();
        int index = 0;
        float r = 0;
        float g = 0;
        float b = 0;
        for (int y = 0; y < tex.height; y++)
        {
            for (int x = 0; x < tex.width; x++)
            {
                r += texColors[index].r;
                g += texColors[index].g;
                b += texColors[index].b;
                index++;
            }
        }
        int total = index;
        return new Color(r / total, g / total, b / total, 0);
        */
        //Color32[]  texColors = DrawingArea.GetComponent<FreeDraw.Drawable>().cur_colors;
        Color32[] texColors = tex.GetPixels32();
        tex.Apply();
        int total = width * height;
        float r = 0;
        float g = 0;
        float b = 0;
        //Debug.Log("Current Index: " + i.ToString());
        //L->R, Bottom->Top
        for (int y = startY; y < startY+height; y++)
        {
            int y2 = (tex.height - y); //invert y to make it top to bottom
            for (int x = startX; x < startX + width; x++)
            {
                int i = y2 * tex.width + x;
                
                r += texColors[i].r;
                g += texColors[i].g;
                b += texColors[i].b;
                
            }
        }

        //Debug.Log(r / (width*height));

        return new Color(r / total, g / total, b / total, 0);
        
    }


}
