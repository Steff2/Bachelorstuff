using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// Guides the player through the planning steps of the Simulation
/// </summary>
public class StatesBySwitch : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public GameObject needle;
    /// <summary>
    /// 
    /// </summary>
    public Transform tumor;
    /// Object in World Space to fixate one the two endpoints of the cameras to, to make it more accurate
    public Transform FixPoint;
    /// <summary>
    /// 
    /// </summary>
    public GameObject Marker;
    /// <summary>
    /// 
    /// </summary>
    public GameObject Cylinder;
    /// <summary>
    /// 
    /// </summary>
    public Camera Cam1;
    /// <summary>
    /// 
    /// </summary>
    RaycastHit hit;
    /// <summary>
    /// Helping text of the planning phase
    /// </summary>
    public Text Planning_Text;
    /// <summary>
    /// Helping text of the Marking phase
    /// </summary>
    public Text Marking_Text;
    /// <summary>
    /// Helping text for the beginning of the actual game after the States phase
    /// </summary>
    public Text Introduction_Text;
    /// <summary>
    /// Helping text of needle placement phase
    /// </summary>
    public Text Needle_Placement_Text;
    /// <summary>
    /// 
    /// </summary>
    public GameObject CameraSkinPoint;
    /// <summary>
    /// Script that gets disabled during this script
    /// </summary>
    public NeedleMovement ascript;

    /// <summary>
    /// Handles the current states
    /// </summary>
    private StateIds currentStateId;

    /// <summary>
    /// Toggles the texts inactive and enters the first phase
    /// </summary>
    public void Start()
    {
        currentStateId = StateIds.Enter_Planning_State;
        Planning_Text.enabled = false;
        Marking_Text.enabled = false;
        Needle_Placement_Text.enabled = false;
        Introduction_Text.enabled = false;
    }


    /// <summary>
    /// Necessary function for routine delay for the text at the final stage
    /// </summary>
    /// <returns></returns>
    IEnumerator CoUpdate()
    {
        yield return new WaitForSeconds(5);
    }


    /// <summary>
    /// Handles all the phases
    /// </summary>
        private void Update()
    {
        switch (currentStateId)
        {
            case StateIds.Enter_Planning_State:
                if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
                {

                    Cam1.transform.position = FixPoint.position;
                    Cam1.transform.rotation = FixPoint.rotation;
                    Cam1.transform.localPosition = new Vector3(0, 0, -100f);

                    CameraSkinPoint.transform.localPosition = new Vector3(-144f, 0, 100f);

                    currentStateId = StateIds.Planning;

                    needle.SetActive(false);
                    Marker.SetActive(true);
                    Planning_Text.enabled = true;
                }
                break;
            case StateIds.Planning:
                if (Input.GetKey(KeyCode.A))
                {
                    FixPoint.Rotate(0, 1f, 0);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    FixPoint.Rotate(-1f, 0, 0);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    FixPoint.Rotate(0, -1f, 0);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    FixPoint.Rotate(1f, 0, 0);
                }

                Marker.transform.position = CameraSkinPoint.transform.position;

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentStateId = StateIds.Enter_Set_Marker_Position_State;
                    Planning_Text.enabled = false;
                }
                break;
            case StateIds.Enter_Set_Marker_Position_State:
                Cam1.enabled = false;
                Marker.SetActive(true);
                Marking_Text.enabled = true;

                currentStateId = StateIds.SetMarkerPosition;

                break;
            case StateIds.SetMarkerPosition:
                if (Input.GetKey(KeyCode.A))
                {
                    Marker.transform.localPosition += new Vector3(-1f, 0, 0);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    Marker.transform.localPosition += new Vector3(0, 1f, 0);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    Marker.transform.localPosition += new Vector3(1f, 0, 0);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    Marker.transform.localPosition += new Vector3(0, -1f, 0);
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentStateId = StateIds.Enter_Set_Needle_Position_State;

                    Marking_Text.enabled = false;
                }
                break;
            case StateIds.Enter_Set_Needle_Position_State:

                needle.SetActive(true);

                if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
                {
                    var Normal_Hit_Vector = hit.normal.normalized;
                    needle.transform.position = hit.point;
                    needle.transform.LookAt(hit.point);

                    Cylinder.transform.localPosition = new Vector3(0, 0, 60);

                }

                Needle_Placement_Text.enabled = true;

                currentStateId = StateIds.SetNeedlePosition;
                break;
            case StateIds.SetNeedlePosition:

                if (Input.GetKey("left"))
                {
                    needle.transform.Rotate(0, -1f, 0);
                }

                if (Input.GetKey("down"))
                {
                    needle.transform.Rotate(-1f, 0, 0);
                }

                if (Input.GetKey("right"))
                {
                    needle.transform.Rotate(0, 1f, 0);
                }

                if (Input.GetKey("up"))
                {
                    needle.transform.Rotate(1f, 0, 0);
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Needle_Placement_Text.enabled = false;
                    currentStateId = StateIds.Game;
                    ascript.enabled = true;
                    Introduction_Text.enabled = true;
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        Introduction_Text.enabled = false;
                    }
                }
                break;

        }
    }
}

public enum StateIds
{
    Enter_Planning_State,
    Planning,
    Enter_Set_Marker_Position_State,
    SetMarkerPosition,
    Enter_Set_Needle_Position_State,
    SetNeedlePosition,
    Game
}
