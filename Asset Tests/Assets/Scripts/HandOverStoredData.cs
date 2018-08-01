using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOverStoredData : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        RadarChart SN = gameObject.GetComponent<RadarChart>();
        SN.SetParameter(2, FeedbackStorage.duration);
    }
}
