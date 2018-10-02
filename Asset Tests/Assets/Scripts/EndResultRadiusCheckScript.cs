using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndResultRadiusCheckScript : MonoBehaviour {

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Radius10"))
        {
            Debug.Log("test collision Radius 10");
        }

        if (collision.collider.CompareTag("Radius30"))
        {
            Debug.Log("test collision Radius 30");
        }
    }
}
