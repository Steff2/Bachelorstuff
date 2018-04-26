using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    void Start()
    {
        transform.position = target.transform.position + new Vector3(-100, 0, 100);

        //Rotation.SetLookRotation(new Vector3(0, 0, 1), new Vector3(0, -1, 0));
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
