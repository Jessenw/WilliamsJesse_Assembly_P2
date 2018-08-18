using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptItem : MonoBehaviour {

    // Keep a count of how many items there are
    private int itemCount1 = 0;
    private int itemCount2 = 0;

    void OnTriggerEnter(Collider item)
    {
        Copper copper = item.gameObject.GetComponent<Copper>();
        if (copper != null)
        {
            Destroy(item.gameObject);
            itemCount1++;
            Debug.Log("Copper detected | count " + itemCount1);
        }
    }
}
