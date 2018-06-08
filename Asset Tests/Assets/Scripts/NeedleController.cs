using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///Handles the movement of the needles
public class NeedleController : MonoBehaviour {
    public float speed; ///<Adjustement of the forward/backward movement of the needle

    public GameObject Seed; ///<The Seed planted in the Tumor

    //private Rigidbody rb;///<The Rigidbody of the Needle
    ///The adjustable Slider in the top right of the game screen
    public Slider SpeedSlider;

/*    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
*/
    /**< Movement of the Needle, vertical and horizontal
    * The forward and backward movement speed can be adjusted through the variable 'speed'
    * Includes the feature of "planting" the seed */
    void Update () {

        speed = SpeedSlider.value;

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, 1f, 0);
        }

        if (Input.GetKey("up"))
        {
            transform.Rotate(1f, 0, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, -1f, 0);
        }

        if (Input.GetKey("down"))
        {
            transform.Rotate(-1f, 0, 0);
        }

        if (Input.GetMouseButton(0))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
            //rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            transform.localPosition -= transform.forward * speed * Time.deltaTime;
            //rb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);
        }

        if(Input.GetKeyUp(KeyCode.B))
        {
            var InstSeed = Instantiate(Seed);
            InstSeed.transform.position = transform.position;
        }
    }
}
