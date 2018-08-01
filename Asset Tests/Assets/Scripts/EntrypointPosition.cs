using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrypointPosition : MonoBehaviour {

    public GameObject entryPoint1;
    public GameObject entryPoint2;
    public GameObject entryPoint3;
    public GameObject entryPoint4;
    public GameObject entryPoint5;

    Vector3 first_point_vector;
    Vector3 second_point_vector;
    Vector3 third_point_vector;
    Vector3 fourth_point_vector;
    Vector3 fifth_point_vector;

    public GameObject tumorPoint;

    bool position_locked;

    int position_counter;

    // Use this for initialization
    void Start () {

        position_counter = 1;
        position_locked = false;

        first_point_vector = entryPoint1.transform.position - tumorPoint.transform.position;
        second_point_vector = entryPoint2.transform.position - tumorPoint.transform.position;
        third_point_vector = entryPoint3.transform.position - tumorPoint.transform.position;
        fourth_point_vector = entryPoint4.transform.position - tumorPoint.transform.position;
        fifth_point_vector = entryPoint5.transform.position - tumorPoint.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        while (position_locked == false)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                position_counter--;

                if (position_counter == 0)
                {
                    position_counter = 5;
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                position_counter++;
            
                if (position_counter == 6)
                {
                    position_counter = 1;
                }
            }

            if(position_counter == 1)
            {
                gameObject.transform.position = entryPoint1.transform.position + 30 * first_point_vector.normalized;
                gameObject.transform.LookAt(tumorPoint.transform.position);
            }

            if (position_counter == 2)
            {
                gameObject.transform.position = entryPoint2.transform.position + 30 * second_point_vector.normalized;
                gameObject.transform.LookAt(tumorPoint.transform.position);
            }

            if (position_counter == 3)
            {
                gameObject.transform.position = entryPoint3.transform.position + 30 * third_point_vector.normalized;
                gameObject.transform.LookAt(tumorPoint.transform.position);
            }

            if (position_counter == 4)
            {
                gameObject.transform.position = entryPoint4.transform.position + 30 * fourth_point_vector.normalized;
                gameObject.transform.LookAt(tumorPoint.transform.position);
            }

            if (position_counter == 5)
            {
                gameObject.transform.position = entryPoint5.transform.position + 30 * fifth_point_vector.normalized;
                gameObject.transform.LookAt(tumorPoint.transform.position);
            }

            if(Input.GetKey(KeyCode.Space))
            {
                position_locked = true;
            }

        }
    }
}
