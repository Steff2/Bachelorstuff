using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextHandler : MonoBehaviour {
    public Text CameraHelper;
    public Image USCamera;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().enabled = true;
        CameraHelper.enabled = false;
        USCamera.enabled = false;

	}
	
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
