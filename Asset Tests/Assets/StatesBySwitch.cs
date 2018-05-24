using UnityEngine;

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
    Vector3 NeedleToFixpoint;


    private StateIds currentStateId;

    public void Start()
    {
        currentStateId = StateIds.Enter_Planning_State;
    }

    private void Update()
    {
        switch (currentStateId)
        {
            case StateIds.Enter_Planning_State:
                if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
                {
                    var DotToTumor = tumor.position - hit.point;
                    var NeedleToMark = needle.transform.forward - needle.transform.position;

                    ///Get the relative position by creating a plane with a vector from the needle to the tumor and a random different vector
                    //FixPoint.position = tumor.position + 40 * DotToTumor.normalized;
                    NeedleToFixpoint = FixPoint.position - needle.transform.position;
                    var PerpVect = Vector3.Cross(NeedleToFixpoint, NeedleToMark);
                    PerpVect.Normalize();
                    Cam1.transform.position = FixPoint.position + 100 * PerpVect;

                    Cam1.transform.LookAt(FixPoint);
                    currentStateId = StateIds.Planning;
                    needle.SetActive(false);
                    Marker.SetActive(false);
                }
                break;
            case StateIds.Planning:
                if (Input.GetKey(KeyCode.A))
                {
                    FixPoint.Rotate(0, 1f, 0, Space.World);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    FixPoint.Rotate(-1f, 0, 0, Space.World);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    FixPoint.Rotate(0, -1f, 0, Space.World);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    FixPoint.Rotate(1f, 0, 0, Space.World);
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    currentStateId = StateIds.Enter_Set_Marker_Position_State;
                }
                break;
            case StateIds.Enter_Set_Marker_Position_State:
                Cam1.enabled = false;
                Marker.SetActive(true);
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

                if (Input.GetKey(KeyCode.B))
                {
                    currentStateId = StateIds.Enter_Set_Needle_Position_State;
                }
                break;
            case StateIds.Enter_Set_Needle_Position_State:
                if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
                {
                    var Normal_Hit_Vector = hit.normal.normalized;
                    needle.transform.position = hit.point;
                    needle.transform.position += Normal_Hit_Vector * 50;
                    needle.SetActive(true);
                }
                    currentStateId = StateIds.SetNeedlePosition;
                break;
            case StateIds.SetNeedlePosition:
                if (Input.GetKey(KeyCode.A))
                {
                    Cylinder.transform.localPosition += new Vector3(-1f, 0, 0);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    Cylinder.transform.localPosition += new Vector3(0, 1f, 0);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    Cylinder.transform.localPosition += new Vector3(1f, 0, 0);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    Cylinder.transform.localPosition += new Vector3(0, -1f, 0);
                }

                if (Input.GetKey("left"))
                {
                    Cylinder.transform.Rotate(0, 1f, 0, Space.World);
                }

                if (Input.GetKey("up"))
                {
                    Cylinder.transform.Rotate(1f, 0, 0, Space.World);
                }

                if (Input.GetKey("right"))
                {
                    Cylinder.transform.Rotate(0, -1f, 0, Space.World);
                }

                if (Input.GetKey("down"))
                {
                    Cylinder.transform.Rotate(-1f, 0, 0, Space.World);
                }

                if (Input.GetMouseButton(0))
                {
                    needle.transform.localPosition += needle.transform.forward;
                    //rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
                }

                if (Input.GetMouseButton(1))
                {
                    needle.transform.localPosition -= needle.transform.forward;
                    //rb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.Space))
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
