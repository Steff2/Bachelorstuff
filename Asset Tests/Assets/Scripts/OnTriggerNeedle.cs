using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*Work in Progress*
//For duration with radar chart
public class OnTriggerNeedle : MonoBehaviour {

    bool Time1triggered = false;
    bool Time2triggered = false;
    Mouse_Needle_Movement MovementScript;

    void Start()
    {
        Mouse_Needle_Movement MovementScript = GameObject.Find("Cylinder").GetComponent<Mouse_Needle_Movement>();
    }

    void Update()
    {
        if (MovementScript.Entering && Time1triggered == false)
        {
            FeedbackStorage.durationToEntry = Time.timeSinceLevelLoad;
            Time1triggered = true;
            Debug.Log(FeedbackStorage.durationToEntry);
        }

        if (Input.GetKeyUp("b") && Time2triggered == false)
        {
            FeedbackStorage.durationAfterEntry = Time.timeSinceLevelLoad - FeedbackStorage.durationToEntry;
            Time2triggered = true;
            Debug.Log(FeedbackStorage.durationAfterEntry);
        }
    }
}
