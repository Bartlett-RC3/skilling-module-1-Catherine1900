using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session1Homework : MonoBehaviour {

    // int -- float -- string

    int normalnumber = 10;
    float normalfloat = 12f;
    string normalstring = "I am a happy string";


    //array

    int[] evenNumber = { 2, 4, 6, 8, 10 };
    int[] oddNumber = new int[5] { 1, 3, 5,7,9};


    //list

    List<float> normalList = new List<float> { 12f, 13f, 14f };

    // Dictionary

    Dictionary<int, string> normalDictionary = new Dictionary<int, string>();




	// Use this for initialization
	void Start () {
	}
	void Start () 
    {

        oddNumber[5] = 11;

        normalList.Add(15f);
        normalList.Add(16f);
        normalList.Add(17f);
        normalList.Add(18f);
        normalList.Add(19f);

        normalDictionary.Add(7, normalstring);
        normalDictionary.Add(8, "I am an unhappy string");
        normalDictionary.Add(9, "I am a blue string");

        if (normalDictionary.ContainsKey(7))
        {

            Debug.Log("When weather is good: " + normalDictionary.Values);

            Debug.Log(normalList[2].ToString());
            Debug.Log(normalList[normalList.Count - 1].ToString());
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(normalnumber + normalfloat + normalstring);
    }
}
