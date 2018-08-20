using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContactFreeze : MonoBehaviour {



    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hello");
        if (col.gameObject.CompareTag("Skin"))
        {
            gameObject.GetComponent<US_Device_Movement>().enabled = false;
        }

    }
}
