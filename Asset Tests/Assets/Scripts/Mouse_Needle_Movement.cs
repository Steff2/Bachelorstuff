using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Movement on the Needle gameobject has gameobject directly in front and Cylinder
public class Mouse_Needle_Movement : MonoBehaviour {

    public GameObject Needletip;
    public GameObject NeedleBack;
    public GameObject Cylinder;

    RaycastHit hit;
    Vector3 RayDirection;

    bool collisionhit = false;

    private float speed = 50.0f;

    int Mode = 0;

    bool Entering = false;

	// Use this for initialization
	void Start () {
        RayDirection = transform.TransformDirection(-Vector3.up);
    }
	
	// Update is called once per frame
	void Update () {
        //Move the needle to the skin while it isn't on it
        if (Physics.Raycast(transform.position, RayDirection, out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.point);
            //Debug.Log(collisionhit);

            //Only move the needle forward until a certain distance and it does not have a collision
            if (hit.distance > .2f && !collisionhit)
            {
                //Needletip.transform.Translate(0, -.5f, 0);
            }
        }

        if (Entering == false)
        {
            if (Mode == 0)
            {
                Needletip.transform.Translate(Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0, Input.GetAxis("Mouse Y") * Time.deltaTime * speed, Space.Self);
            }

            if (Mode == 1)
            {
                Needletip.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, -Input.GetAxis("Mouse X")) * Time.deltaTime * speed);
            }
        }

        if (Mode == 2)
        {
            Needletip.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * speed * 10, 0));
        }
        

        if (Mode == 3)
        {
            Needletip.transform.Translate(0, -Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * speed * 10, 0, Space.Self);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Mode = Mode + 1;

            if (Mode == 4)
            {
                Mode = 0;
            }
            Debug.Log(Mode);
        }
        //For now the player is only supposed to rotate and go forward and backward after entering
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Entering = true;
        }

        //if(Input.GetKeyUp("b"))
        //{
            if (Physics.SphereCast(NeedleBack.transform.position, 25f, Needletip.transform.position - NeedleBack.transform.position, out hit, 100))
            {
               // Debug.Log("test collision 25");

                if (Physics.SphereCast(NeedleBack.transform.position, 15f, Needletip.transform.position - NeedleBack.transform.position, out hit, 100))
                {
                    //Debug.Log("test collision 15");
                   // Debug.Log(hit.point);
                }
        }
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("test");

        collisionhit = true;
    }
    void OnCollisionStay(Collision collision)
    {
        collisionhit = true;
        float ContactPointtoNeedleTipDistance = 99999;
        Vector3 ClosestContactHitPoint;


        //Check for all the collision points and get the closest
        //Get the orthogonal projection of the contact point
        //and set the needles rotation accordingly
        //transform.Translate(0, 1f, 0, Space.Self);
        int i = 0;
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 proj;
            i++;
            if ((contact.point - Needletip.transform.position).magnitude < ContactPointtoNeedleTipDistance && (Mode == 0 || Mode == 3) )
            {
                ContactPointtoNeedleTipDistance = (contact.point - Needletip.transform.position).magnitude;
                ClosestContactHitPoint = contact.point;
                proj = Needletip.transform.forward - (Vector3.Dot(Needletip.transform.forward, contact.normal)) * contact.normal;
                Needletip.transform.rotation = Quaternion.Slerp(Needletip.transform.rotation, Quaternion.LookRotation(proj, contact.normal), .02f);
            }
        }
    }
    //move it to the skin if it just left the collision
    void OnCollisionExit(Collision collision)
    {
        collisionhit = false;
    }
}
