using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child 
{
    float grade;
    float joy;
    string name;
    static string nameList[];
    // Start is called before the first frame update
    void Start()
    {
        grade = Random.Range(40, 90);
        joy = grade + Random.Range(-20, 20);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
