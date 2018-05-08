using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    //Sets the position of the Camera
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
