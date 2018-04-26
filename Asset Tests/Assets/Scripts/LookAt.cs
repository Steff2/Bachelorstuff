using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform target;
    public int speed;

    void Start()
    {
        speed = 3;
    }
    // Update is called once per frame
    void Update () {

        Vector3 relativepos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativepos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);

	}
    //Hier noch Funktion für ClickAction mit speed änderung einfügen
}
