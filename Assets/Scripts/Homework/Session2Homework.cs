using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session2Homework : MonoBehaviour {

    public  static string[] cats = { "kitty", "doll", "shortHair" ,"Tom"};
    static string[] dogs = { "autumn", "henry", "doctor" };
    int numberOfCats = cats.Length;
    int numberOfDogs = dogs.Length;

	// Use this for initialization
	void Start () {
        if (numberOfCats > numberOfDogs  ){

            Debug.Log("The number of cats is more than the dogs!");
        }
        else{
            Debug.Log("The number of dogs is more than the cats!");

        }
        string[] qualitiesOfAnimals = { "smart", "adorable", "loyal", "proud" };
        for (int i = 0; i < cats.Length-1 ;i++ )
        {
            Debug.Log("a"+ qualitiesOfAnimals[i]+ "cat is" + cats[i]);

        }
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
