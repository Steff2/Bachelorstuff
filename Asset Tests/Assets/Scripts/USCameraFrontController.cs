using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Set the front view ultrasound camera
public class USCameraFrontController : MonoBehaviour {

    public Transform needle;
    
    // Set the position of the camera to that of the needle 
	void Start () {
        gameObject.transform.position = needle.position;
        gameObject.transform.LookAt(needle);
	}
	// Always keep the camera at an offset while moving the needle
	void Update () {
        gameObject.transform.position = needle.position;
        gameObject.transform.localPosition -= new Vector3(0, -20, 99);

        gameObject.transform.LookAt(needle);
    }
}
