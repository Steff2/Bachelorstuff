using UnityEngine;

public class SetMarkerPosition : State
{
    public Camera Cam1;
    public GameObject Marker;

    public SetMarkerPosition(Character gameState) : base(gameState)
    {
    }

    public override void Tick()
    {
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

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            gameState.SetState(new SetNeedlePosition(gameState));
        }
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        Cam1.enabled = false;
    }
}
