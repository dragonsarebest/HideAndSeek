using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateQuestionsAndPapers : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset textFile;
    public int numberOfQuestions = 5;
    public float lineSpacing = 0.15f;


    private GameObject[] QuestionPieces;
    public GameObject questionPrefab;
    public GameObject startLineloc;
    public GameObject drawingArea;

    void Start()
    {
        string contents = textFile.ToString();
        char[] splitchar = { '\n' };
        string[] questions = contents.Split(splitchar);

        Transform inital = gameObject.transform;
        QuestionPieces = new GameObject[numberOfQuestions];

        Texture paper = gameObject.GetComponent<SpriteRenderer>().sprite.texture;

        for (int i = 0; i < questions.Length && i < numberOfQuestions; i++)
        {
            string currentQuestion = questions[i];
            Vector3 currentPos = startLineloc.transform.position - new Vector3(0, lineSpacing * i, 0);

            GameObject tempGameObj = Instantiate(questionPrefab, Vector3.zero, Quaternion.identity);
            tempGameObj.transform.parent = gameObject.transform;
            tempGameObj.transform.position = currentPos;

            tempGameObj.GetComponent<GradeStudent>().setText(currentQuestion, drawingArea, gameObject);

            QuestionPieces[i] = tempGameObj;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int counter = 0;
        for (int i = 0; i < QuestionPieces.Length && i < numberOfQuestions; i++)
        {
            counter += (QuestionPieces[i].GetComponent<GradeStudent>().failed ? 1 : 0);
        }
        Debug.Log(counter);
    }
}
