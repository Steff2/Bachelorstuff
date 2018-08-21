using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles the game preview camera
/// </summary>
public class CameraController : MonoBehaviour {

    public Transform target;///< The Object the camera is fixated on
    public Transform tumorPoint;

    ///Sets the position of the Camera
    void Update()
    {        
        Vector3 positionVector = tumorPoint.position - target.position;
        transform.position = target.position - 100 * positionVector.normalized;
        transform.position += new Vector3(0, 5, 0);
        gameObject.transform.LookAt(target);
    }
}
