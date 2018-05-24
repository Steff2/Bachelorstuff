using UnityEngine;

public class SetNeedlePosition : State
{
    public Camera Cam1;
    public GameObject Marker;
    public GameObject needle;

    public SetNeedlePosition(GameState gameState) : base(gameState)
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
        needle.SetActive(true);
    }
}