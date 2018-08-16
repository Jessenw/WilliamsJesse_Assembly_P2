using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptItem : MonoBehaviour {

    public GameObject machine;

    // Keep a count of how many items there are
    private int itemCount1 = 0;
    private int itemCount2 = 0;

    void OnTriggerEnter(Collider item)
    {
        Debug.Log("Collision");
        Destroy(item.gameObject);

        itemCount1++;
    }
}
