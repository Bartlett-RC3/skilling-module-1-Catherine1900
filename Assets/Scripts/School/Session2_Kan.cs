using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RC3Student;

public class Session2_Kan : MonoBehaviour
{

    int number1 = 10;
    int number2 = 10;
    int number3;

    bool someBool = false;
    string someName = "name";

    string[] tutorNames = { "Dave", "Tyson", "Jordi", "Octavian", "Panos" };
    // Use this for initialization
    void Start()
    {
        Debug.Log("A tutor is: " + tutorNames[0]);
        Debug.Log("A tutor is: " + tutorNames[1]);
        Debug.Log("A tutor is: " + tutorNames[2]);
        Debug.Log("A tutor is: " + tutorNames[3]);

        for (int i = 0; i <= tutorNames.Length - 1; i++)
        {
            Debug.Log("A tutor is: " + tutorNames[i]);
        }
        for (int counter = 0; counter <= number2; counter++)
        {
            Debug.Log("Counting... " + counter);
        }

        //For each loop
        foreach (string tutorName in tutorNames)
        {
            Debug.Log(tutorName);
        }

        if (number1 < number2)
        {
            Debug.Log("number 1 is smaller than number 2");
        }
        else
        {

            Debug.Log("number 2 is smaller than number 1");

        }


        if (number1 < number2 && someBool == true)
        {

            Debug.Log("answer to both question is yes ");
        }

        if (number1 < number2)
        {

            if (someBool == true)
            {
                Debug.Log("answer to both question is yes ");
            }
        }

        if (number1 < number2 || someBool == true)
        {
            Debug.Log("answer to both question is yes ");
        }

        if ((number1 < number2 && someBool == true) && (someBool == true && someName == "name"))
        {
            Debug.Log("it is too confusing! simple please!");
        }

        number3 = (number1 < number2) ? 100 : 200;


    }
        // Update is called once per frame
        void Update()
        {

        }
    
}