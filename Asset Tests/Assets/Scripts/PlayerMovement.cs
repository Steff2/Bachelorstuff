using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Transform Test;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        gameObject.transform.position = Test.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if(Input.GetKey("w"))
        {
            rb.MovePosition(transform.position + new Vector3(0f, 1f * speed, 0f) * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            rb.MovePosition(transform.position + new Vector3(-1f * speed, 0f, 0f) * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            rb.MovePosition(transform.position + new Vector3(1f * speed, 0f, 0f) * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.MovePosition(transform.position + new Vector3(0f, -1f * speed, 0f) * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            rb.MovePosition(transform.position + new Vector3(0f, 0f, -1f * speed) * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            rb.MovePosition(transform.position + new Vector3(0f, 0f, 1f * speed) * Time.deltaTime);
        }

    }
}
