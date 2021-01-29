using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeStudent : MonoBehaviour
{
    private Color start;
    private Color current;
    public GameObject obj;
    private FreeDraw.DrawingSettings drawSurf;
    private Texture2D tex;

    public float FailThreshold = 60.0f;
    public bool erase = false;
    public Color drawColor = new Color(255f, 0f, 0f, 255f);
    public Color eraseColor = new Color(255f, 255f, 255f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(obj);
        tex = obj.GetComponent<SpriteRenderer>().sprite.texture;
        drawSurf = obj.GetComponent<FreeDraw.DrawingSettings>();
        //Debug.Log(tex);
        start = AverageColor(tex);
    }

    // Update is called once per frame
    void Update()
    {
        current = AverageColor(tex);
        //Debug.Log(current);
        //Debug.Log(start);

        if(current.r >= FailThreshold)
        {
            //Debug.Log("YOU FAIELD");
        }
        else
        {
            //Debug.Log(current.r);
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

    Color AverageColor(Texture2D tex)
    {
        Color32[] texColors = tex.GetPixels32();
        int total = texColors.Length;
        float r = 0;
        float g = 0;
        float b = 0;
        for (var i = 0; i<total; i++) {
            r += texColors[i].r;
            g += texColors[i].g;
            b += texColors[i].b;
        }
        
        return new Color(r/total, g/total, b/total, 0);
    }


}
