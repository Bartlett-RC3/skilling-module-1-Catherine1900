using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Session4_kan : MonoBehaviour
{
    public GameObject PrefabReference;
    IEnumerator createPrefab;

    // Use this for initialization
    void Start()
    {
        //HOW DO WE INSTANTIATE(MAKE) A NEW PREFAB?
        //give a object position, ratation, parent

        Vector3 prefabPosition = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
        Quaternion prefabRotation = Quaternion.identity;

        for (int i = 0; i < 10; i++)
        {
            GameObject myPrefab = Instantiate(PrefabReference, prefabPosition, prefabRotation);

            foreach (Transform child in myPrefab.transform)
            {
                child.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
            }

            myPrefab.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }

        createPrefab = DropPrefabFromHeight();
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(createPrefab);
        Debug.Log(Time.time);
        if (Time.time > 5)
        {
            StopCoroutine(createPrefab);
            StopAllCoroutines();
        }
    }

    IEnumerator DropPrefabFromHeight()
    {
        while (true)
        {
            Vector3 PrefabPos = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(-10, 10));
            Quaternion PrefabRot = new Quaternion(UnityEngine.Random.Range(0, 90), UnityEngine.Random.Range(0, 90), UnityEngine.Random.Range(0, 90), 1);
            Instantiate(PrefabReference, PrefabPos, PrefabRot);

            yield return new WaitForSeconds(5);
        }

    }
}

