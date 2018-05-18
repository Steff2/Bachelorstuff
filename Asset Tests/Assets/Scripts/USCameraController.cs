using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///Handles the placing and movement of the side ultrasound camera
public class USCameraController : MonoBehaviour {
    /// <summary>
    /// 
    /// </summary>
    public Transform needle;
    /// <summary>
    /// 
    /// </summary>
    public Transform tumor;
    /// Object in World Space to fixate one the two endpoints of the cameras to, to make it more accurate
    public Transform FixPoint;
    /// <summary>
    /// 
    /// </summary>
    public GameObject Marker;
    /// <summary>
    /// 
    /// </summary>
    RaycastHit hit;
    /// <summary>
    /// 
    /// </summary>
    Vector3 NeedleToFixpoint;

    /// Move and place the camera
    void Update () {
        if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
        {
            var DotToTumor = tumor.position - hit.point;
            var NeedleToMark = needle.forward - needle.position;

            ///Get the relative position by creating a plane with a vector from the needle to the tumor and a random different vector
            FixPoint.position = tumor.position + 40 * DotToTumor.normalized;
            NeedleToFixpoint = FixPoint.position - needle.position;
            var PerpVect = Vector3.Cross(NeedleToFixpoint, NeedleToMark);
            PerpVect.Normalize();
            gameObject.transform.position = FixPoint.position + 100 * PerpVect;

            gameObject.transform.LookAt(FixPoint);
        }
	}
}
