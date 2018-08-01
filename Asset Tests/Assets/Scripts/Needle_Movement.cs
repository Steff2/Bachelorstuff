using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// Guides the player through the planning steps of the Simulation
/// </summary>
public class Needle_Movement : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public GameObject needle;
    /// <summary>
    /// 
    /// </summary>
    public GameObject Cylinder;

    /// <summary>
    /// Toggles the texts inactive and enters the first phase
    /// </summary>
    public void Start()
    {

    }

    /// <summary>
    /// Handles the movement of the needle
    /// </summary>
    private void Update()
    {
        if (Input.GetKey("left"))
            {
                Cylinder.transform.Rotate(0, 0, -1f);
            }

        if (Input.GetKey("up"))
            {
                Cylinder.transform.Rotate(1f, 0, 0);
            }

        if (Input.GetKey("right"))
            {
                Cylinder.transform.Rotate(0, 0, 1f);
            }

        if (Input.GetKey("down"))
            {
            Cylinder.transform.Rotate(-1f, 0, 0);
            }

        if (Input.GetKey("w"))
            {
                Cylinder.transform.localPosition += new Vector3(0,0,1) * 2;
            }

        if (Input.GetKey("a"))
            {
                Cylinder.transform.localPosition += new Vector3(-1f, 0, 0) * 2;
            }

        if (Input.GetKey("s"))
            {
                Cylinder.transform.localPosition -= new Vector3(0, 0, 1) * 2;
            }

        if (Input.GetKey("d"))
            {
                Cylinder.transform.localPosition += new Vector3(1f, 0, 0) * 2;
            }

        if (Input.GetMouseButton(0))
            {
                needle.transform.localPosition -= needle.transform.up * 10 * Time.deltaTime;
            }

        if (Input.GetMouseButton(1))
            {
                needle.transform.localPosition += needle.transform.up * 10 * Time.deltaTime;
            }
        }
    }
