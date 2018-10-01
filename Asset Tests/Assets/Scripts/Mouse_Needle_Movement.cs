using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Movement on the Needle gameobject has gameobject directly in front and Cylinder
public class Mouse_Needle_Movement : MonoBehaviour {

    public GameObject Needletip;
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
        if (Physics.Raycast(transform.position, RayDirection, out hit, Mathf.Infinity, 1 << 10))
        {
            if ((transform.position - hit.point).magnitude > 1 && !collisionhit)
            {
                transform.Translate(0, -.5f, 0);
            }
        }

        if (Entering == false)
        {
            if (Mode == 0)
            {
                transform.Translate(Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0, Input.GetAxis("Mouse Y") * Time.deltaTime * speed, Space.Self);
            }

            if (Mode == 1)
            {
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, -Input.GetAxis("Mouse X")) * Time.deltaTime * speed);
            }
        }

        if (Mode == 2)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * speed * 10, 0));
        }
        

        if (Mode == 3)
        {
            transform.Translate(0, -Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * speed * 10, 0, Space.Self);
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
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");

        collisionhit = true;

        float ContactPointtoNeedleTipDistance = 99999;
        Vector3 ClosestContactHitPoint;


        //Check for all the collision points and get the closest
        transform.Translate(0, 5f, 0, Space.Self);
        int i = 0;
        foreach (ContactPoint contact in collision.contacts)
        {
            i++;
            if ((contact.point - Needletip.transform.position).magnitude < ContactPointtoNeedleTipDistance)
            {
                ContactPointtoNeedleTipDistance = (contact.point - Needletip.transform.position).magnitude;
                ClosestContactHitPoint = contact.point;
                transform.position = ClosestContactHitPoint;
            }
        }
        Debug.Log(i);

    }
    //move it to the skin if it just left the collision
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("testexit");
        collisionhit = false;
        transform.Translate(0, -5f, 0, Space.Self);
    }
}
