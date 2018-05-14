using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles the placement of the markers and their corresponding needles
/// </summary>
public class NeedlePlacement : MonoBehaviour {

    public GameObject Tumor; //The tumor Object
    public Projector Marker; ///The Object Projecting the Marker
    //public List<int> MarkerList; ///Marker counter with list.size and Elements contain Needle count
    public GameObject Needle; //The Needle Object

    [SerializeField]
    ///Range of position variation of the Marker
    //private Vector3 Range; //Adjustment of the Placement of the Markers

    /**< Sets the Markers with adjustable Range and sets the corresponding Needles which amount per marker is changeable,
      *through the point of the Raycast hit with the Skin from the Projector
      *Needles here are facing the Marker only, for now */
    void Start () {
        RaycastHit hit;

        if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
        {
            var EntryDirection = Tumor.transform.position - hit.point;
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

}
