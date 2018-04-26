using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedlePlacement : MonoBehaviour {

    public int DistanceToBody = 4;
    //public int NeedleCount;
    public GameObject Tumor;
    public GameObject RedDot;


	// Use this for initialization
	void Start () {
        
        Vector3 TumorToDot = RedDot.transform.position - Tumor.transform.position;

        transform.position = DistanceToBody * TumorToDot;
        transform.LookAt(RedDot.transform);

        //int x = 1;
        //while(x!=NeedleCount)
        //{
        //  var AnotherNeedle = Instantiate(gameObject);
        //}

    }

}
