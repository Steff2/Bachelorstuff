using UnityEngine;

public class Planning : State
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
    public Camera Cam1;
    /// <summary>
    /// 
    /// </summary>
    RaycastHit hit;
    /// <summary>
    /// 
    /// </summary>
    Vector3 NeedleToFixpoint;


    private Vector3 destination;

    public Planning(GameState gameState): base (gameState)
    {
    }

    public override void Tick()
    {
        if (Input.GetKey(KeyCode.A))
        {
            FixPoint.Rotate(0, 1f, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            FixPoint.Rotate(1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            FixPoint.Rotate(0, -1f, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            FixPoint.Rotate(-1f, 0, 0);
        }

        if(Input.GetKey(KeyCode.KeypadEnter))
        {
            gameState.SetState(new SetMarkerPosition(gameState));
        }
    }

    public override void OnStateEnter()
    {
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
        }
    }
    public override void OnStateExit()
    {
        needle.SetActive(false);
    }
}
