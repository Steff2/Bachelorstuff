using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carry_Over_Checkmark : MonoBehaviour {

    Toggle Guiding_Assistance_Toggle;

    // Use this for initialization
    void Start () {
        Guiding_Assistance_Toggle = gameObject.GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(FeedbackStorage.guiding_Assistance);
        FeedbackStorage.guiding_Assistance = Guiding_Assistance_Toggle.isOn;
	}
}
