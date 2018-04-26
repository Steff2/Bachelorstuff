using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USCameraController : MonoBehaviour {

    public Transform needle;
    public Transform tumor;
    public Transform FixPoint;
    public Transform RedDot;
	
	// Update is called once per frame
	void Update () {
        var DotToTumor = tumor.position - RedDot.position;
        //var NeedleToTumor = tumor.position - needle.position;
        Vector3 NeedleToFixpoint;
        var NeedleToX = needle.forward - needle.position;

        FixPoint.position = tumor.position + 40 * DotToTumor.normalized;
        NeedleToFixpoint = FixPoint.position - needle.position;
        var PerpVect = Vector3.Cross(NeedleToFixpoint, NeedleToX);
        PerpVect.Normalize();
        gameObject.transform.position = FixPoint.position + 100 * PerpVect;

        gameObject.transform.LookAt(FixPoint);
	}
}
