using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// This class handles the switching of the Ultrasound cameras
public class CameraSwitch : MonoBehaviour
{

    public Camera cam1; ///< The side camera view
    public Camera cam2; ///< The front camera view

    ///Sets cam1 active and cam2 inactive
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }

    /// Switches the active stance of the cams through a button press from the player
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}