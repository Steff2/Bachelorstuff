using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movement of the needle after deciding the entry position with the guiding system
/// <summary>
public class GuidingAssistanceMovement : MonoBehaviour {

    public GameObject Seed;

    void Update () {
        gameObject.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 50f * FeedbackStorage.AdjustableSpeed, Space.Self);
        if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(Seed, gameObject.transform.position, Seed.transform.rotation);
        }
    }
}
