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
        currentStateId = StateIds.Planning;
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
            case StateIds.Planning:
                if (Input.GetKey("left"))
                {
                    Cylinder.transform.Rotate(0, 0, 1f);
                }

                if (Input.GetKey("up"))
                {
                    Cylinder.transform.Rotate(1f, 0, 0);
                }

                if (Input.GetKey("right"))
                {
                    Cylinder.transform.Rotate(0, 0, -1f);
                }

                if (Input.GetKey("down"))
                {
                    Cylinder.transform.Rotate(-1f, 0, 0);
                }

                if (Input.GetKey("w"))
                {
                    Cylinder.transform.localPosition += needle.transform.forward * 3;
                }

                if (Input.GetKey("a"))
                {
                    Cylinder.transform.localPosition += new Vector3(-1f, 0, 0) * 3;
                }

                if (Input.GetKey("s"))
                {
                    Cylinder.transform.localPosition -= needle.transform.forward * 3;
                }

                if (Input.GetKey("d"))
                {
                    Cylinder.transform.localPosition += new Vector3(1f, 0, 0) * 3;
                }

                if (Input.GetMouseButton(0))
                {
                    needle.transform.localPosition -= needle.transform.up * 10 * Time.deltaTime;
                }

                if (Input.GetMouseButton(1))
                {
                    needle.transform.localPosition += needle.transform.up * 10 * Time.deltaTime;
                }

                if (Input.GetKeyUp("space"))
                {
                    currentStateId = StateIds.Game;
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
