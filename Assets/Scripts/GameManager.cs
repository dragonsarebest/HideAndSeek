using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int curday;
    public int totaldays;
    int curstudent;
    public int totalstudents;
    public int minigames;
    static public int minigamesComplete;

    void Start()
    {
        curday = 0;
        curstudent = 0;

        //we give this the number of students we want
        StaticChildren.GenStudents(totalstudents);
        StaticChildren.currentStudent = StaticChildren.students[curstudent];
        StaticChildren.OnStart();
        Debug.Log(StaticChildren.students.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if(minigames <= minigamesComplete)
        {
            newStudent();
        }
    }

    void newStudent()
    {
        TransitionHandler transhand = StaticChildren.CallTransition();
        transhand.playWalking();
        curstudent++;
        minigamesComplete = 0;
        if (curstudent >= totalstudents)
        {
            newDay();

        }
        StaticChildren.currentStudent = StaticChildren.students[curstudent];

    }
    void newDay()
    {
        curstudent = 0;
        curday++;
        if (curday >= totaldays)
        {
            //game ends

        }

        
    }
}
