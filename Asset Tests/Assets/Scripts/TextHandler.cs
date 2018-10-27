using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Sets the display text and the helping text
/// </summary>
public class TextHandler : MonoBehaviour {

    bool toggle = false;

    public GameObject PlanText;
	/// <summary>
    /// Initialize the active/inactive states of the different Texts
    /// </summary>
	void Start () {

        PlanText.GetComponent<Text>().enabled = true;
        //gameObject.GetComponent<Text>().enabled = false;

    }
	
    /// <summary>
    /// Switches Texts and image after a button press from the player
    /// </summary>
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlanText.GetComponent<Text>().enabled = false;
            gameObject.GetComponent<Text>().enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab) && toggle == true)
        {
            gameObject.GetComponent<Text>().enabled = true;
            toggle = false;
        }

        if (Input.GetKeyUp(KeyCode.Tab) && toggle == false)
        {
            gameObject.GetComponent<Text>().enabled = false;
            toggle = true;
        }
    }
}
