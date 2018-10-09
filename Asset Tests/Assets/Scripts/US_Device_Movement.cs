using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//standard follow script
public class US_Device_Movement : MonoBehaviour
{
    public Transform toFollow;
    private Vector3 offset;

    void Start()
    {
        offset = toFollow.position - transform.position;
    }
    void Update()
    {
        transform.position = toFollow.position - offset;
        transform.rotation = toFollow.rotation;
    }
}
