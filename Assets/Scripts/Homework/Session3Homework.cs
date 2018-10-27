using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session3Homework : MonoBehaviour
{

    public GameObject CubePrefab;
    Renderer m_Renderer;
    Renderer child_renderer;

    // Use this for initialization
    void Start()
    {

        Instantiate(CubePrefab, this.transform);
        m_Renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        //    * Create a cube and move it across the screen
        foreach (Transform child in this.transform)
        {
            child.Translate(Time.deltaTime, 0, 0);
        }

        //     * Create a cube and change its colour when key is pressed or mouse is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_Renderer.material.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
       
    }
}