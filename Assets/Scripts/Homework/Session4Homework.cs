using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session4Homework : MonoBehaviour {
    public GameObject cube;
    IEnumerator changeColor;
    IEnumerator breed;
    private List<GameObject> cubes = new List<GameObject>();

    // Use this for initialization
    void Start () {
        //for (int i = 0; i < 10; i++)
        //{
        //    Vector3 prefabPosition = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
        //    Quaternion prefabRotation = Quaternion.identity;
        //    GameObject myPrefab = Instantiate(cube, prefabPosition, prefabRotation);

        breed = BreedNewCube();
        changeColor = ChangeColorRandom();
        StartCoroutine(breed);
        StartCoroutine(changeColor);
        // Debug.Log(Time.time);


        if (Time.time > 20)
        {
            StopCoroutine(changeColor);
            StopAllCoroutines();
        }

        //}

    }

	
	// Update is called once per frame
	void Update () {

       
    }
    IEnumerator ChangeColorRandom()
    {
        while (true)
        {
          foreach (var _cube in cubes )
            {
                _cube.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value,Random.value);
            }
            yield return new WaitForSeconds(2);
        }


    }

    IEnumerator BreedNewCube()
    {
        while (true)
        {
            Vector3 PrefabVs = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(-10, 10));
            Quaternion PrefabRs = new Quaternion(UnityEngine.Random.Range(0, 90), UnityEngine.Random.Range(0, 90), UnityEngine.Random.Range(0, 90), 1);
            GameObject _cube = Instantiate(cube, PrefabVs, PrefabRs);
            cubes.Add(_cube);

            yield return new WaitForSeconds(2);
        }


    }
}
