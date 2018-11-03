using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSpeed : MonoBehaviour {

    Slider speedSlider;
	// Use this for initialization
	void Start () {
        speedSlider = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        FeedbackStorage.AdjustableSpeed = speedSlider.value;
        Debug.Log(FeedbackStorage.AdjustableSpeed);
	}
}
