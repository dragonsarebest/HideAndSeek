using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Endgame : MonoBehaviour
{
    public Text studentsFailed;
    public Text GameOver;
    public Image blackness;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTheGame()
    {
        GameOver.gameObject.SetActive(true);
        studentsFailed.gameObject.SetActive(true);
        blackness.gameObject.SetActive(true);
        int num = 0;
        for(int i = 0; i < StaticChildren.students.Count; i++)
        {
            if (StaticChildren.students[i].grade < 60)
            {
                num++;
            }
        }
        string txt = "You crushed " + num.ToString() + " students hopes and dreams!!";
        studentsFailed.text = txt;

    }
}
