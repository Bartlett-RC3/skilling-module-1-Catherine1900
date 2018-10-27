using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session3_Kan : MonoBehaviour {
    public GameObject cubeprefab;
    public GameObject Light;
    public GameObject objectReference;
    public int spacing = 10;
    public int gridX = 10;
    public int gridY = 10;

    int var = 10;

    // Always here. 

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(cubeprefab, new Vector3 (i*spacing , j*spacing,0), Quaternion.identity,this.transform);
            }
        }
    

	}
	
	// Update is called once per frame
	void Update () {
        // Time.realtimeSinceStartup
        // Time.deltaTime
        // Time.time
        Debug.Log("This computer can redner a frame in: " + Time.deltaTime);
        Debug.Log("Since I started playing the game this amount of time has passed: " + Time.timeSinceLevelLoad);
        Debug.Log("omputer has counted this ammount of frames: " + Time.frameCount);


        foreach(Transform child in this.transform)
        {
            child.Translate(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        }

        // rotatiom
        // rotate children gameobject around y axis

        foreach (Transform child in this.transform)
        {
            child.RotateAroundLocal(Vector3.up, Random.value);
        }

        foreach (Transform child in this.transform)
        {
            child.localScale = new Vector3(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
        }


        // Record the cubes orginal scale
        Vector3[] originalScale = new Vector3[this.transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            originalScale[i] = transform.GetChild(i).localScale;
        }


        // keyboard input
        if (Input.GetKey(KeyCode.Space))
        {
            // if i press space
            // if i re
         
            foreach (Transform child in this.transform)
            {

                child.localScale = child.localScale * 5f;
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localScale = originalScale[i];
            }
        }

        // MOUSE PRESSED (O left, 1 right, 2 middle)
        if (Input.GetMouseButton(0))
        {
            Light.GetComponent<Light>().color = new Color(Random.value, Random.value, Random.value);
        }


    }
}