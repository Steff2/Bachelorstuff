using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowScript : MonoBehaviour {

    public Transform toFollow;
    private Vector3 offset;

    void Start()
    {
        offset = toFollow.position - transform.position;
    }
    void Update()
    {
        transform.position = toFollow.position - offset;
        transform.LookAt(toFollow);
    }
}
