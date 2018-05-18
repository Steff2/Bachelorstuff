using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


/// <summary>
/// Sets the display text and the helping text
/// </summary>
public class TextHandler : MonoBehaviour {

    /// <summary>
    /// Helping text above the Ultrasound image
    /// </summary>
    public Text CameraHelper;
    /// <summary>
    /// 
    /// </summary>
    public RawImage USCamera;

	/// <summary>
    /// Initialize the active/inactive states of the different Texts
    /// </summary>
	void Start () {
        gameObject.GetComponent<Text>().enabled = true;
        CameraHelper.enabled = false;
        USCamera.enabled = false;

	}
	
    /// <summary>
    /// Switches Texts and image after a button press from the player
    /// </summary>
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<Text>().enabled = false;
            CameraHelper.enabled = true;
            USCamera.enabled = true;
        }
    }
}
