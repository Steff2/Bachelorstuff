using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Apply the chosen guidance settings from the menu scene on the scripts
public class ApplySettingsScript : MonoBehaviour {

    EntrypointPosition Guidance_Script;
    Mouse_Needle_Movement No_Guidance_Script;

    // Use this for initialization
    void Start () {
        Guidance_Script = GameObject.Find("NeedleTip").GetComponent<EntrypointPosition>();
        No_Guidance_Script = GameObject.Find("Cylinder").GetComponent<Mouse_Needle_Movement>();

        if(FeedbackStorage.guiding_Assistance)
        {
            Guidance_Script.enabled = true;
            No_Guidance_Script.enabled = false;
            Debug.Log("test guidance script");
            Debug.Log(Guidance_Script.enabled);
            Debug.Log("test no guidance script");
            Debug.Log(No_Guidance_Script.enabled);
        }
        else
        {
            Guidance_Script.enabled = false;
            No_Guidance_Script.enabled = true;
            Debug.Log("test guidance script");
            Debug.Log(Guidance_Script.enabled);
            Debug.Log("test no guidance script");
            Debug.Log(No_Guidance_Script.enabled);
        }
    }

}
