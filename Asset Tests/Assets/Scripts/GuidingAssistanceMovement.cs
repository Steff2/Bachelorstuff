﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movement of the needle after deciding the entry position with the guiding system
public class GuidingAssistanceMovement : MonoBehaviour {

    public GameObject Seed;

    void Update () {
        gameObject.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 50f * 10f, Space.Self);
        if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(Seed, gameObject.transform.position, Seed.transform.rotation);
        }
    }
}
