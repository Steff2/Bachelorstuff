using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*Work in Progress*
//For duration with radar chart
public class OnTriggerNeedle : MonoBehaviour {

    public float TimeSinceEnter;

	void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Skin"))
        {
            TimeSinceEnter += Time.timeSinceLevelLoad;
        }
    }

    void Update()
    {
        if (Input.GetKey("space"))
        {
            TimeSinceEnter = Time.timeSinceLevelLoad - TimeSinceEnter;
            FeedbackStorage.duration = TimeSinceEnter;
        }
    }
}
