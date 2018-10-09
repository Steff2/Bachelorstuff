using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Measuring and saving the time until entry in the skin and time from entering until final position
public class OnTriggerNeedle : MonoBehaviour {

    bool Time1triggered = false;
    bool Time2triggered = false;
    Mouse_Needle_Movement MovementScript;

    void Awake()
    {
        MovementScript = GameObject.Find("Cylinder").GetComponent<Mouse_Needle_Movement>();
    }

    void Update()
    {
        if (MovementScript.EnteringSkin && Time1triggered == false)
        {
            FeedbackStorage.DurationToEntry = Time.timeSinceLevelLoad;
            Time1triggered = true;
            Debug.Log(FeedbackStorage.durationToEntry);
        }

        if (Input.GetKeyUp("b") && Time2triggered == false)
        {
            FeedbackStorage.DurationAfterEntry = Time.timeSinceLevelLoad - FeedbackStorage.durationToEntry;
            Time2triggered = true;
            Debug.Log(FeedbackStorage.durationAfterEntry);
        }
    }
}
