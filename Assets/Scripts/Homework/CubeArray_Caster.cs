using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeArray_Caster : MonoBehaviour
{
    GameObject[] _cubeArray = new GameObject[8];
    public GameObject _cube1;
    public GameObject _cube2;
    public GameObject _cube3;
    public GameObject _cube4;
    public GameObject _cube5;
    public GameObject _cube6;
    public GameObject _cube7;
    public GameObject _cube8;


    // Start is called before the first frame update
    void Start()
    {
        _cubeArray[0] = _cube1;
        _cubeArray[1] = _cube2;
        _cubeArray[2] = _cube3;
        _cubeArray[3] = _cube4;
        _cubeArray[4] = _cube5;
        _cubeArray[5] = _cube6;
        _cubeArray[6] = _cube7;
        _cubeArray[7] = _cube8;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 raycastingDirction = transform.forward;

        RaycastHit objectInFront;

        if (Physics.Raycast(transform.position, raycastingDirction, out objectInFront))
        {
            Debug.Log("Object in front is" + objectInFront.transform.name);
            //objectInFront.transform.GetComponent<ListenScript>().seen = true;
            Destroy(objectInFront.transform.gameObject);
        }

    }
}

