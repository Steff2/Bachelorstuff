using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour {
    public float speed; //Adjustement of the forward/backward movement of the needle

    public GameObject Seed; //The Seed planted in the Tumor

    private Rigidbody rb;//The Rigidbody of the Needle

    // Sets all the Markers on the Skin and places the Needles via Raycast
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Movement of the Needle, vertical and horizontal
    // The forward and backward movement speed can be adjusted through the variable 'speed'
    // Includes the feature of "planting" the seed
    void Update () {
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, 0.25f, 0);
        }

        if (Input.GetKey("up"))
        {
            transform.Rotate(0.25f, 0, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, -0.25f, 0);
        }

        if (Input.GetKey("down"))
        {
            transform.Rotate(-0.25f, 0, 0);
        }

        if (Input.GetMouseButton(0))
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            rb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);
        }

        if(Input.GetKeyUp("space"))
        {
            var InstSeed = Instantiate(Seed);
            InstSeed.transform.position = transform.position;
        }
    }
}
