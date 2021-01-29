using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeStudent : MonoBehaviour
{
    private Color32 start;
    private Color32 current;
    public GameObject obj;
    private Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(obj);
        tex = obj.GetComponent<SpriteRenderer>().sprite.texture;
        start = AverageColor(tex);
    }

    // Update is called once per frame
    void Update()
    {
        current = AverageColor(tex);
        Debug.Log(current);
        Debug.Log(start);
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
