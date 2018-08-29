using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidingLine : MonoBehaviour {

    public Vector3 startingPoint;
    public Vector3 endPoint;

    // Use this for initialization
    void Start () {

        LineRenderer line = gameObject.GetComponent<LineRenderer>();

        line.sortingLayerName = "OnTop";
        line.sortingOrder = 5;
        line.positionCount = 2;
        line.SetPosition(0, startingPoint);
        line.SetPosition(1, endPoint);
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.useWorldSpace = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
