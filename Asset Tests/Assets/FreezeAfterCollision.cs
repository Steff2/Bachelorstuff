using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAfterCollision : MonoBehaviour
{

    Vector3 After_Collision_Transform;
    bool collision = false;

    private void Update()
    {
        
        if(collision)
        {
            gameObject.transform.position = After_Collision_Transform;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    void OnCollisionEnter(Collision col)
{

    if (col.gameObject.CompareTag("Skin"))
    {
        Debug.Log("Hello");
        After_Collision_Transform = transform.position;
        collision = true;
    }

}
}
