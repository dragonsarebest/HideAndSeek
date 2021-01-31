using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child 
{
    float grade;
    float joy;
    string name;
//    static string nameList[Liam Olivia,Noah,"Emma"
//3   Oliver  Ava
//4   William Sophia
//5   Elijah  Isabella
//6   James   Charlotte
//7   Benjamin    Amelia
//8   Lucas   Mia
//9   Mason   Harper
//10  Ethan   Evelyn];
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
