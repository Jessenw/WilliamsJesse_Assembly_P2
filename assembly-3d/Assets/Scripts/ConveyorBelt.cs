using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script controls the movement of items on a conveyor belt
 */
public class ConveyorBelt : MonoBehaviour
{

    /* The point where an item on the belt is trying to get to */
    public Transform endpoint;

    public float speed;

    /*
     * If a rigid-body collides with the belt, move it towards the endpoint
     */
    void OnTriggerStay(Collider obj)
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, endpoint.position, speed * Time.deltaTime);
    }
}
