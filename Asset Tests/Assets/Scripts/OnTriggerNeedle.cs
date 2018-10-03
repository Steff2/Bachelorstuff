using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*Work in Progress*
//For duration with radar chart
public class OnTriggerNeedle : MonoBehaviour {

    bool Time1triggered = false;
    bool Time2triggered = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && Time1triggered == false)
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
