using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour {
    //public int NeedleCount;
    //public MarkerCount;
    public float speed;
    public GameObject Tumor;
    public GameObject RedDot;
    public Transform staticcamera;

    private Rigidbody rb;

    [SerializeField]
    //Range of position variation of the Marker
    private Vector3 Range;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RaycastHit hit;

        var Ray = Tumor.transform.position - staticcamera.position;


        if (Physics.Raycast(staticcamera.position, Ray, out hit))
        {
            //for (int i = 0; i < MarkerCount; i++)
            //{
                GameObject dot = Instantiate<GameObject>(RedDot);
                var hitRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                dot.transform.position = hit.point;
                //gameObject.transform.rotation = hitRotation;
                //gameObject.transform.position = hit.point;

                //var FacingDirection = Tumor.transform.position - gameObject.transform.position;

                //needle.transform.LookAt(Tumor.transform);
                if (Range == new Vector3(0, 0, 0))
                {
                    dot.transform.position += new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
                    dot.transform.rotation = hitRotation;
                }
                else
                {
                    dot.transform.position += new Vector3(Random.Range(-Range.x, Range.x), 0, Random.Range(-Range.z, Range.z));
                    dot.transform.rotation = hitRotation;
                }
            //}
            Vector3 TumorToDot = dot.transform.position - Tumor.transform.position;
            transform.position = dot.transform.position;
            transform.position += 50 * TumorToDot.normalized;
            transform.LookAt(dot.transform);
        }

        //int x = 1;
        //while(x!=NeedleCount)
        //{
        //  var AnotherNeedle = Instantiate(gameObject);
        //}

    }

    // Update is called once per frame
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
    }
}
