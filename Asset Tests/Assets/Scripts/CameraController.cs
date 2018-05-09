using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles the game preview camera
/// </summary>
public class CameraController : MonoBehaviour {

    public Transform target;///< The Object the camera is fixated on

    ///Sets the position of the Camera
    void Start()
    {
        transform.position = target.transform.position + new Vector3(-90, 30, 90);
    }

    //private void Update()
    //{

    //    float xAxisValue = Input.GetAxis("Horizontal");
    //    float zAxisValue = Input.GetAxis("Vertical");
    //    if (Camera.current != null)
    //    {
    //        Camera.current.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
    //    }
    //}
}
