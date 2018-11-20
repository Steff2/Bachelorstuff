using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for choosing your Entrypoint in the Guiding Assistant
/// <summary>
public class EntrypointPosition : MonoBehaviour {

    public GameObject entryPoint1;
    public GameObject entryPoint2;
    public GameObject entryPoint3;
    public GameObject entryPoint4;
    public GameObject entryPoint5;

    public GameObject needle1;
    public GameObject needle2;
    public GameObject needle3;
    public GameObject needle4;
    public GameObject needle5;

    public GameObject OP_Plan1;
    public GameObject OP_Plan2;
    public GameObject OP_Plan3;
    public GameObject OP_Plan4;
    public GameObject OP_Plan5;

    Vector3 first_point_vector;
    Vector3 second_point_vector;
    Vector3 third_point_vector;
    Vector3 fourth_point_vector;
    Vector3 fifth_point_vector;

    Renderer ren;
    Material[] mat;

    public GameObject tumorPoint;

    GuidingAssistanceMovement GuidanceAssistMovement;

    int position_counter;

    void Start () {

        position_counter = 1;

        GuidanceAssistMovement = gameObject.GetComponent<GuidingAssistanceMovement>();
        GuidanceAssistMovement.enabled = false;

    }
    /// <summary>
    /// Sets the position
    /// Change the positions depending on the counter
    /// let the needle look at the tumor
    /// if the position is chosen, lock it in and color the needle in the position
    /// set the picture of the endposition active for ultrasound
    /// <summary>
    void Update () {
        
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                position_counter--;

                if (position_counter == 0)
                {
                    position_counter = 5;
                }

                if (position_counter == 1)
                {
                    gameObject.transform.position = entryPoint1.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }

                if (position_counter == 2)
                {
                    gameObject.transform.position = entryPoint2.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }

                if (position_counter == 3)
                {
                    gameObject.transform.position = entryPoint3.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }

                if (position_counter == 4)
                {
                    gameObject.transform.position = entryPoint4.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }

                if (position_counter == 5)
                {
                    gameObject.transform.position = entryPoint5.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                position_counter++;
            
                if (position_counter == 6)
                {
                    position_counter = 1;
                }

                if (position_counter == 1)
                {
                    gameObject.transform.position = entryPoint1.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }

                if (position_counter == 2)
                {
                    gameObject.transform.position = entryPoint2.transform.position;
                    //gameObject.transform.rotation = needle2.transform.rotation;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-90, 0, 0);
            }

                if (position_counter == 3)
                {
                    gameObject.transform.position = entryPoint3.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }

                if (position_counter == 4)
                {
                    gameObject.transform.position = entryPoint4.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }

            if (position_counter == 5)
                {
                    gameObject.transform.position = entryPoint5.transform.position;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    //gameObject.transform.Rotate(-180, 0, 0);
                }
            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                if(position_counter == 1)
                {
                    ren = needle1.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan1.SetActive(true);
                }

                if (position_counter == 2)
                {
                    ren = needle2.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan2.SetActive(true);
                }

                if (position_counter == 3)
                {
                    ren = needle3.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan3.SetActive(true);
                }

                if (position_counter == 4)
                {
                    ren = needle4.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan4.SetActive(true);
                }

                if (position_counter == 5)
                {
                    ren = needle5.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan5.SetActive(true);
                }

              gameObject.GetComponent<EntrypointPosition>().enabled = false;
              GuidanceAssistMovement.enabled = true;
        }

    }
}
