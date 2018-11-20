using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Apply the chosen guidance settings from the menu scene on the scripts and components
/// <summary>
public class ApplySettingsScript : MonoBehaviour {

    EntrypointPosition Guidance_Script;
    Mouse_Needle_Movement No_Guidance_Script;
    CameraController MainCameraScript;
    Text TextForGuidance;
    Text TextWithoutGuidance;
    MeshCollider NeedleCollider_Mesh;

    /// <summary>
    /// Get the Scripts and components from objects
    /// <summary>
    void Start () {

        Guidance_Script = GameObject.Find("NeedleTip").GetComponent<EntrypointPosition>();
        No_Guidance_Script = GameObject.Find("Cylinder").GetComponent<Mouse_Needle_Movement>();
        MainCameraScript = GameObject.Find("Main Camera").GetComponent<CameraController>();
        NeedleCollider_Mesh = GameObject.Find("Cylinder").GetComponent<MeshCollider>();
        TextForGuidance = GameObject.Find("PlanText").GetComponent<Text>();

        if (FeedbackStorage.guiding_Assistance)
        {
            Guidance_Script.enabled = true;
            No_Guidance_Script.enabled = false;
            MainCameraScript.enabled = true;
            NeedleCollider_Mesh.enabled = false;
            TextForGuidance.enabled = true;
        }
        else
        {
            Guidance_Script.enabled = false;
            No_Guidance_Script.enabled = true;
            MainCameraScript.enabled = false;
            NeedleCollider_Mesh.enabled = true;
            TextForGuidance.enabled = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            AppHelper.Quit();
        }
    }

}
