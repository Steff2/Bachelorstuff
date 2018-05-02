using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour {
    //public int NeedleCount; //Amount of Needles placed
    //public int MarkerCount; //Amount of Markers on the skin
    public float speed; //Adjustement of the forward/backward movement of the needle

    public GameObject Tumor; //The tumor Object
    public Projector Marker; //The Object Projecting the Marker
    public GameObject Seed;
    public GameObject Skin; //The Skin Object

    private Rigidbody rb;
    [SerializeField]
    //Range of position variation of the Marker
    private Vector3 Range; //Adjustment of the Placement of the Markers

    // Sets all the Markers on the Skin and places the Needles via Raycast
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RaycastHit hit;

        if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
        {
            var EntryDirection = Tumor.transform.position - hit.point;
            gameObject.transform.position = hit.point - EntryDirection.normalized * 10;
            gameObject.transform.LookAt(Tumor.transform);
        }
        /*
        for (int i = 0; i < MarkerCount; i++)
        {
            var MarkerInst = Instantiate(Marker, Marker.transform.position);
            MarkerInst.transform.position += new Vector3(Random.Range(15, 20), Random.Range(15, 20), 0);
            if (Physics.Raycast(MarkerInst.transform.position, MarkerInst.transform.forward, out hit))
            {
                var EntryDirection = Tumor.transform.position - hit.point;
                Instantiate(gameObject, transform.position);
                gameObject.transform.position = hit.point - EntryDirection.normalized * 10;
                gameObject.transform.LookAt(Tumor.transform);
            }
        }*/

        //int x = 1;
        //while(x!=NeedleCount)
        //{
        //  var AnotherNeedle = Instantiate(gameObject);
        //}

    }

    // Update is called once per frame
    // Movement of the Needle, vertical and horizontal
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
