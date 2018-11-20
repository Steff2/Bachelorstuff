using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movement on the Needle gameobject has gameobject directly in front and Cylinder
/// <summary>
public class Mouse_Needle_Movement : MonoBehaviour {

    public GameObject Needletip;
    public GameObject NeedleBack;
    public GameObject Cylinder;
    public GameObject Seed;
    public GameObject USCamera;
    public GameObject USDevice;
    public GameObject NeedleObject;
    

    bool HitPointRead = false;

    RaycastHit hit;

    Vector3 RayDirection;
    Vector3 Entrypoint;
    Vector3 Fixed_Position_In_front_of_Skin_USDevice;
    Vector3 Fixed_Position_In_front_of_Skin_Cam;
    Vector3 USDevicePosition;

    Quaternion USCamRotationFixpoint;
    Quaternion fromRotation;
    Quaternion toRotation;

    MeshCollider CylinderMeshCollider;
    US_Device_Movement DeviceMovement;

    private bool collisionhit = false;

    private int Mode = 0;

    public bool EnteringSkin = false;

    // Use this for initialization
    void Start () {

        CylinderMeshCollider = gameObject.GetComponent<MeshCollider>();
        DeviceMovement = GameObject.Find("US_Device").GetComponent<US_Device_Movement>();
        RayDirection = transform.TransformDirection(-Vector3.up);
    }
    /// <summary>
    /// Check the distance to the skin and move if necessary
    /// rotate needle to match collision point normal
    /// Move according to the mode with the movement of the mouse
    /// and check on the endposition if the danger radii were triggered
    /// <summary>
    void Update () {
        //Move the needle to the skin while it isn't on it
        if (Physics.Raycast(transform.position, RayDirection, out hit, Mathf.Infinity, 1<<10))
        {
            //Only move the needle forward until a certain distance and it does not have a collision
            if (hit.distance > 1f && !collisionhit) Needletip.transform.Translate(0, .75f, 0);
            if (EnteringSkin == false && Mode == 0 || Mode == 3)
            {

                //Transform the needle to point at the hit triangle
                fromRotation = Needletip.transform.rotation;

                //Get the rotation to rotate to
                toRotation = Quaternion.FromToRotation(-Needletip.transform.up, hit.normal);

                if (hit.normal == -Needletip.transform.up) return;
                if (hit.normal != -Needletip.transform.up)
                {
                    //slowly go to this rotation from the current one
                    Needletip.transform.rotation = Quaternion.Slerp(fromRotation, toRotation, .2f);
                }
                
            }
        }

        if (EnteringSkin == false)
        {
            //Move along the x and y direction by moving your mouse
            if (Mode == 0)
            {
                DeviceMovement.enabled = true;
                Needletip.transform.Translate(Input.GetAxis("Mouse X") * Time.deltaTime * FeedbackStorage.AdjustableSpeed, 0, -Input.GetAxis("Mouse Y") * Time.deltaTime * FeedbackStorage.AdjustableSpeed, Space.Self);
            }
            //Rotate around the point the needle tip is at by moving your mouse
            if (Mode == 1)
            {

                DeviceMovement.enabled = false;

                USDevice.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * Time.deltaTime * FeedbackStorage.AdjustableSpeed, 0, Input.GetAxis("Mouse X")));
                Needletip.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * Time.deltaTime * FeedbackStorage.AdjustableSpeed, 0, Input.GetAxis("Mouse X")));
            }
            //Rotate the needle itself by moving your mouse
            if (Mode == 2)
            {
                DeviceMovement.enabled = true;

                Needletip.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * FeedbackStorage.AdjustableSpeed * 10, 0));
            }
        }        
        //Move back and forth with the mouse wheel
        if (Mode == 3)
        {
            DeviceMovement.enabled = false;

            Needletip.transform.Translate(0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * FeedbackStorage.AdjustableSpeed * 10, 0, Space.Self);

            EnteringSkin = true;

            if (Physics.Raycast(transform.position, RayDirection, out hit, Mathf.Infinity) && HitPointRead == false)
            {
                Entrypoint = hit.point;

                USCamRotationFixpoint = USCamera.transform.rotation;
                Fixed_Position_In_front_of_Skin_Cam = USCamera.transform.position;
            }

            CylinderMeshCollider.enabled = false;

            USCamera.transform.position = Fixed_Position_In_front_of_Skin_Cam;
            USCamera.transform.rotation = USCamRotationFixpoint;

            HitPointRead = true;
        }
        //There is no Mode == 4 so make it loop to 0
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Mode = Mode + 1;

            if (Mode == 4)
            {
                Mode = 0;
            }
            Debug.Log(Mode);
        }
        //Signal for getting the distance to surface and set the "Entering" state
        if (Input.GetKeyUp("b"))
        {
            Instantiate(Seed, gameObject.transform.position, Seed.transform.rotation);

            FeedbackStorage.DistanceToSurface = (Needletip.transform.position - Entrypoint).magnitude;

            if (Physics.SphereCast(NeedleBack.transform.position, 25f, Needletip.transform.position - NeedleBack.transform.position, out hit, 100))
            {

                FeedbackStorage.LessDangerousRadiusTriggered = true;

                if (Physics.SphereCast(NeedleBack.transform.position, 15f, Needletip.transform.position - NeedleBack.transform.position, out hit, 100))
                {
                    FeedbackStorage.DangerRadiusTriggered = true;
                }

                else
                {
                    FeedbackStorage.DangerRadiusTriggered = false;
                }

            }
            else
            {
                FeedbackStorage.LessDangerousRadiusTriggered = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        collisionhit = true;
    }
    void OnCollisionStay(Collision collision)
    {
        collisionhit = true;
    }
    
    //move it to the skin if it just left the collision
    void OnCollisionExit(Collision collision)
    {
        collisionhit = false;
    }
}
