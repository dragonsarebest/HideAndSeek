using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child 
{
    public float grade;
    public float joy;
    public string name;

    public Child()
    {
        grade = Random.Range(70, 90);
        joy = grade + Random.Range(-20, 20);
        name = StaticChildren.nameList[Mathf.RoundToInt(Random.Range(0, StaticChildren.nameList.Count - 1))];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
