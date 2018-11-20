using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Keep the settings for checkmark for the guiding assistance over the scene change
/// <summary>
public class Carry_Over_Checkmark : MonoBehaviour {

    Toggle Guiding_Assistance_Toggle;

    void Start () {
        Guiding_Assistance_Toggle = gameObject.GetComponent<Toggle>();
	}
	
	void Update () {
        FeedbackStorage.guiding_Assistance = Guiding_Assistance_Toggle.isOn;
	}
}
