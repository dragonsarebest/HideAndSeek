using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Uihandler : MonoBehaviour
{
    public Text studentname;
    public Text grade;
    public Text motivation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        studentname.text = StaticChildren.currentStudent.name;
        grade.text = (string)("Grade: " + StaticChildren.currentStudent.grade);
        motivation.text = (string)("Motivation: " + StaticChildren.currentStudent.joy);

    }
}
