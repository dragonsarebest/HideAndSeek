using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticChildren 
{
    public static GameObject transitions;

    public static List<Child> students = new List<Child>();
    public static Child currentStudent;
    public static List<string> nameList = new List<string> {"Jack","Lewis","Ryan","Cameron","James","Andrew","Liam","Matthew","Jamie","Callum","Ross","Jordan","Daniel","Kieran","Connor","Scott","Kyle",
        "David","Adam","Dylan","Michael","Ben","Thomas","Craig","Nathan","Sean","John","Aaron","Calum","Christopher","Alexander","Robert","Euan","Joshua","Declan","Aidan","Mark","Robbie","Luke","Fraser",
        "Reece","William","Ewan","Joseph","Paul","Brandon","Lee","Owen","Josh","Samuel","Finlay","Stuart","Rhys","Stephen","Rory","Jake","Steven","Sam","Jay","Benjamin","Ethan","Harry","Shaun","Aiden","Darren",
        "Blair","Marc","Dean","Taylor","Angus","Gregor","Conor","Jonathan","Patrick","Ciaran","Greg","Jason","George","Logan","Peter","Bradley","Max","Arran","Mohammed","Morgan","Oliver","Gary","Murray",
        "Louis","Martin","Alan","Alistair","Grant","Joe","Keir","Duncan","Leon","Mitchell","Nicholas","Tyler","Gavin","Hamish","Charles","Iain","Kerr","Anthony","Kevin","Ronan","Stewart","Brendan",
        "Charlie","Jacob","Kai","Zak","Alasdair","Keiran","Evan","Lucas","Marcus","Ian","Neil","Struan","Alex","Douglas","Finn","Ruairidh","Tom","Bruce","Dillon","Elliot","Fergus","Kian","Niall",
        "Bailey","Brian","Colin","Innes","Richard","Allan","Caleb","Calvin","Corey","Dominic","Edward","Harris","Brodie","Arron","Drew","Campbell","Billy","Donald","Gordon","Greig","Alastair","Barry",
        "Glen","Reiss","Ruaridh","Travis","Graeme","Rowan","Shane","Conner","Harrison","Philip","Lachlan","Leo","Henry","Jordon","Jude","Lennon","Mathew","Archie","Justin","Bryan","Dale","Danny","Joel",
        "Kane","Kieron","Mason","Cian","Isaac","Kenneth","Noah","Rian","Tony","Ali","Callan","Cole","Derek","Findlay","Gabriel","Jon","Lyle","Oscar","Russell","Tommy","Zachary","Daryl","Ellis","Graham",
        "Kristopher","Marco","Anton","Bobby","Brad","Christian","Garry","Keith","Kieren","Regan","Rohan","Saul","Stefan","Ayden","Blake","Bryce","Harvey","Hayden","Hugh","Jak","Lloyd","Magnus","Myles",
        "Sebastian","Zac","Antony","Brogan","Conall","Frazer","Jackson","Nathaniel","Nico","Reagan","Timothy","Zack","Alfie","Cory","Dane","Elliott","Frederick","Glenn","Jai","Jed","Laurence","Matt",
        "Robin","Scot","Toby","Zain","Antonio","Cain","Cieran","Cody","Curtis","Damien","Eoin","Ewen","Flynn","Francis","Frank","Gareth","Gerard","Hamzah","Haydn","Johnathan","Jonathon","Kelvin","Kurt",
        "Luc","Luca","Malcolm","Martyn","Omar","Ricky","Ruairi","Sandy","Shawn","Simon","Sonny","Troy","Vincent","Alister","Baillie","Brooklyn","Byron","Conrad","Declyn","Guy","Hassan","Jayden","Kalvin",
        "Kirk","Kris","Kristofer","Lawrence","Levi","Mackenzie","Mohamed","Murdo","Ritchie","Roan","Ruari","Usman","Aarron","Alec","Amaan","Blaine","Brandyn","Brett","Cal","Corrie","Dillan","Eoghan",
        "Finley","Humza","Jasper","Johnny","Keiren","Keiron","Kurtis"
 };

    public static void GenStudents(int num)
    {
        for (int i = 0; i < num; i++)
        {
            students.Add(new Child());
        }
    }

    public static void OnStart()
    {
        transitions = GameObject.Find("Transitions");
        transitions.SetActive(false);
    }

    public static TransitionHandler CallTransition()
    {
        transitions.SetActive(true);
        return transitions.GetComponent<TransitionHandler>();
    }

    public static void DisableTransitions()
    {
        transitions.SetActive(false);
    }
}
