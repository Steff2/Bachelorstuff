using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContactFreeze : MonoBehaviour {

    Transform After_Collision_Transform;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Skin"))
        {
            Debug.Log("Hello");
            After_Collision_Transform.position = gameObject.transform.position;

            GetComponent<US_Device_Movement>().enabled = false;

            gameObject.transform.position = After_Collision_Transform.position;
        }

    }
}
