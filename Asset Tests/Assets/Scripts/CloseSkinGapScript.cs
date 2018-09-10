using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSkinGapScript : MonoBehaviour {

    public GameObject needle;
    public GameObject Cylinder;


    RaycastHit hit;
    Vector3 RayDirection;

    // Use this for initialization
    void Start () {
        RayDirection = transform.TransformDirection(-Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {

		if(Physics.Raycast(Cylinder.transform.position, RayDirection, out hit))
        {
            if((Cylinder.transform.position - hit.point).magnitude > 70)
            {
                needle.transform.Translate(0, -1f, 0);
            }
        }
	}
}
