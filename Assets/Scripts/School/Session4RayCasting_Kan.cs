using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session4RayCasting_Kan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
