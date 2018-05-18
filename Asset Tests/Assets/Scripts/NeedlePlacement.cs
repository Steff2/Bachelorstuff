using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Handles needle placement and its movement
/// </summary>
public class NeedlePlacement : MonoBehaviour
{

    public GameObject Tumor; ///<The tumor Object
    public GameObject Marker; ///<The Object Projecting the Marker

    //public List<int> MarkerList; ///Marker counter with list.size and Elements contain Needle count

    public GameObject Needle; ///<The Needle Object
    public GameObject Skin; ///<The Skin Object for initializing its tag for collision compare
    public GameObject Seed; ///<The Seed planted in the Tumor

    public float speed; ///<Adjustement of the forward/backward movement of the needle


    ///The adjustable Slider in the top right of the game screen
    public Slider SpeedSlider;

    ///The Direction from the Skin to the Tumor the needle is facing
    public Vector3 EntryDirection;

    [SerializeField]
    ///Range of position variation of the Marker
    //private Vector3 Range; //Adjustment of the Placement of the Markers

    /**< Sets the Markers with adjustable Range and sets the corresponding Needles which amount per marker is changeable,
      *through the point of the Raycast hit with the Skin from the Projector
      *Needles here are facing the Marker only, for now */
    void Start()
    {
        RaycastHit hit;
        Skin.tag = "Skin";

        if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit///<The Hitpoint of a Raycast))
        {
            EntryDirection = Tumor.transform.position - hit.point;
            Needle.transform.position = hit.point - EntryDirection.normalized * 50;
            Needle.transform.LookAt(Tumor.transform);
            /*for (int i = 0; i < MarkerList[0]; i++)
            {
                var Needle1 = Instantiate(Needle);
                Needle1.transform.position = hit.point - EntryDirection.normalized * 10;
                //Needle1.transform.position += new Vector3(Random.Range(10, 15), Random.Range(10, 15), 0);
                Needle1.transform.LookAt(hit.transform);
            }*/
        }
        /*
        for (int i = 2; i < MarkerList.Count; i++)
        {

            var MarkerInst = Instantiate(Marker, Marker.transform.position);
            MarkerInst.transform.position += new Vector3(Random.Range(15, 20), Random.Range(15, 20), 0);
            if (Physics.Raycast(MarkerInst.transform.position, MarkerInst.transform.forward, out hit))
            {
                var EntryDirection = Tumor.transform.position - hit.point;
                for(int j = 1; j<MarkerList[i-1]; j++)
                {
                    Needles = Instantiate(Needle, transform.position);
                    Needles.transform.position = hit.point - EntryDirection.normalized * 10;
                    Needles.transform.LookAt(hit.transform);
                }
            }
        }*/
    }

    /**< Movement of the Needle, vertical and horizontal
* The forward and backward movement speed can be adjusted through the variable 'speed'
* Includes the feature of "planting" the seed */
    void Update()
    {

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

        if (Input.GetKeyUp(KeyCode.B))
        {
            ///The Instatiated Seed
            var InstSeed = Instantiate(Seed);
            InstSeed.transform.position = transform.position;
        }
    }

    ///Gets called when the object hits a trigger 
    void OnTriggerEnter(Collider other)
    {
         Marker.SetActive(false);
    }
}
