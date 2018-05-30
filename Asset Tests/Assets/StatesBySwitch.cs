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
    /// 
    /// </summary>
    public Text Planning_Text;
    /// <summary>
    /// 
    /// </summary>
    public Text Marking_Text;
    /// <summary>
    /// 
    /// </summary>
    public Text Needle_Placement_Text;
    /// <summary>
    /// 
    /// </summary>
    public GameObject CameraSkinPoint;
    /// <summary>
    /// 
    /// </summary>
    public NeedleMovement ascript;

    Vector3 NeedleToFixpoint;


    private StateIds currentStateId;

    public void Start()
    {
        currentStateId = StateIds.Enter_Planning_State;
        Planning_Text.enabled = false;
        Marking_Text.enabled = false;
        Needle_Placement_Text.enabled = false;
    }

    private void Update()
    {
        switch (currentStateId)
        {
            case StateIds.Enter_Planning_State:
                if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
                {
                    var NeedleToMark = needle.transform.forward - needle.transform.position;

                    ///Get the relative position by creating a plane with a vector from the needle to the tumor and a random different vector
                    NeedleToFixpoint = FixPoint.position - needle.transform.position;

                    var PerpVect = Vector3.Cross(NeedleToFixpoint, NeedleToMark);
                    PerpVect.Normalize();

                    Cam1.transform.position = FixPoint.position;
                    Cam1.transform.rotation = FixPoint.rotation;
                    Cam1.transform.localPosition = new Vector3(0, 0, -100f);

                    CameraSkinPoint.transform.localPosition = new Vector3(-144f, 0, 100f);

                    //Cam1.transform.LookAt(FixPoint);

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
