using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Set the front view ultrasound camera
public class USCameraFrontController : MonoBehaviour {

    public Transform needle;
    
	// Use this for initialization
	void Start () {
        gameObject.transform.position = needle.position;
        gameObject.transform.LookAt(needle);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = needle.position;
        gameObject.transform.localPosition -= new Vector3(0, -20, 99);

        gameObject.transform.LookAt(needle);
    }
}
