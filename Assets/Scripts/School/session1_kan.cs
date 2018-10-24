using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class session1_kan : MonoBehaviour
{

    // 1. Variable
    // Scope -- Type -- Name -- Value(just one value)

    // Number
    public int myInteger = 145;
    int largestInteger = int.MaxValue;
    int smallestInteger = int.MinValue;

    double myDouble = 54.3;
    double maxDouble = double.MaxValue;

    float myFloat = 32.456f;

    // Text
    string myString = "This is the new awesome RC3! Better than ever : )";

    // Logical
    bool myboolean = true;
    bool falseboolean = false;

    // 2.Data structures
    // Scope -- Type -- Values (can take in many values)

    //Array
    int[] myIntArray = { 1, 2, 3, 4, 5, 6 };
    int[] twentyElementArray = new int[20];
    int[,] xyArray = new int[4, 5];
    // comes out null

    double[] doubleArray = { 20.4, 11.23, 45, 72.9 };

    // list
    List<int> myList = new List<int>();

    // Dictionary
    Dictionary<string, string> movingAnimals = new Dictionary<string, string>();




    // 2.Functions
    // Scope -- Type -- Variables -- Body (Instructions)






    // Use this for initialization
    void Start()
    {
        //  Array adding values
        myIntArray[2] = 388;

        // Array retrive value
        Debug.Log(myIntArray[2].ToString());

        movingAnimals.Add("flying", "eagle");
        movingAnimals.Add("flying", "parrot");
        movingAnimals.Add("walking", "human");
        movingAnimals.Add("walking", "dog");

        if (movingAnimals.ContainsKey("flying"))
        {
            Debug.Log("A flying animal is: " + movingAnimals.Values);

            // List adding values
            myList.Add(4331);
            myList.Add(41);
            myList.Add(1);

            // List retrive values
            Debug.Log(myList[2].ToString());
            Debug.Log(myList[myList.Count - 1].ToString());

            //Clearing the list 
            myList.Clear();


        }

    }

    // Update is called once per frame
    void Update()
    {
        myFloat = 13.4f;
    }

    // Number addition function
    // Scope -- Type -- Variables -- Body (Instructions)

    float NumberAddition(float a, float b)
    {
        float additionResult = a + b;
        return additionResult;
    }

    void PrintSomeNumbers()
    {
        Debug.Log(myList[0]);
        Debug.Log(myInteger);
    }

}