using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the Marker Movement/placement
/// </summary>
public class Marker_Movement : MonoBehaviour {
    /// <summary>
    /// 
    /// </summary>
    public GameObject Needle;
    /// <summary>
    /// 
    /// </summary>
    RaycastHit hit;

	/// <summary>
    /// Moves the Marker with the needle as its child
    /// </summary>
	void Update () {

        if (Physics.Raycast(Needle.transform.position, Needle.transform.forward, out hit))
        {
            transform.position = hit.point;
            transform.localPosition += new Vector3(0, 0, -65);
            transform.LookAt(Needle.transform);
            //Marker.transform.localPosition += new Vector3(0, 0, 10);
        }
    }
}
