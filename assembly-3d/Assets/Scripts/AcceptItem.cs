using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptItem : MonoBehaviour {

    public GameObject machine;

    void OnTriggerEnter(Collider item)
    {
        Debug.Log("Collision");
        Destroy(item.gameObject);
    }
}
