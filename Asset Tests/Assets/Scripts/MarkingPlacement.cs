using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkingPlacement : MonoBehaviour {

    public GameObject skin;
    public GameObject Tumor;
    public Transform staticcamera;
    public Transform needle;

    [SerializeField]
    //Range of position variation of the Marker
    private Vector3 Range;


	//Sets the Dot to the area where a direct Line from Camera to Tumor hits the skin
	void Start () {
        RaycastHit hit;

        var Ray = Tumor.transform.position - staticcamera.position;

        GameObject dot = Instantiate<GameObject>(gameObject);

        if (Physics.Raycast(staticcamera.position, Ray, out hit))
        {
            var hitRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
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
            
        }
    }
	
	
}
