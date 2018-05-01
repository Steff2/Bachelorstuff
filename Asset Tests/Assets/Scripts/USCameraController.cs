using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Handles the placing and movement of the side ultrasound camera
public class USCameraController : MonoBehaviour {

    public Transform needle;
    public Transform tumor;
    public Transform FixPoint;
    public Transform RedDot;
	
	// Move and place the camera
	void Update () {
        var DotToTumor = tumor.position - RedDot.position;
        //var NeedleToTumor = tumor.position - needle.position;
        Vector3 NeedleToFixpoint;
        var NeedleToX = needle.forward - needle.position;
        //Get the relative position by creating a plane with the vector from needle to tumor and a random other vector
        FixPoint.position = tumor.position + 40 * DotToTumor.normalized;
        NeedleToFixpoint = FixPoint.position - needle.position;
        var PerpVect = Vector3.Cross(NeedleToFixpoint, NeedleToX);
        PerpVect.Normalize();
        gameObject.transform.position = FixPoint.position + 100 * PerpVect;

        gameObject.transform.LookAt(FixPoint);
	}
}
