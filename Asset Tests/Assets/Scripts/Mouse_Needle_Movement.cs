using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Needle_Movement : MonoBehaviour {

    private float speed = 20.0f;

    int Mode = 0;

    bool Entering = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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

            if (Mode == 2)
            {
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * speed * 10, 0));
            }
        }

        if (Mode == 3)
        {
            transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * speed, Space.Self);
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

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Entering = true;
        }
    }
}
