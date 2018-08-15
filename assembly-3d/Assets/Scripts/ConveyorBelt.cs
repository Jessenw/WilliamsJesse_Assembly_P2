using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    public GameObject belt;
    public Transform endpoint;
    public float speed;

    void OnTriggerStay(Collider item)
    {
        item.transform.position = Vector3.MoveTowards(item.transform.position, endpoint.position, speed * Time.deltaTime);
    }
}
