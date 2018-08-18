using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptItem : MonoBehaviour {

    [SerializeField]
    private GameObject engine;

    // Keep a count of how many items there are
    private int itemCount1 = 0;
    private int itemCount2 = 0;

    private float timer = 2.0f;

    void Update()
    {
        if ((itemCount2 >= 2) && (itemCount1 >= 1))
        {
            if (timer < 0)
            {
                Vector3 spawnPos = new Vector3(transform.position.x + 1.5f, transform.position.y + 1.0f, transform.position.z);
                Instantiate(engine, spawnPos, transform.rotation);

                itemCount2 -= 2;
                itemCount1--;

                timer = 2.0f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider item)
    {
        Copper copper = item.gameObject.GetComponent<Copper>();
        if (copper != null)
        {
            Destroy(item.gameObject);
            itemCount1++;
            Debug.Log("Copper detected | count " + itemCount1);
        }

        Steel steel = item.gameObject.GetComponent<Steel>();
        if (steel != null)
        {
            Destroy(item.gameObject);
            itemCount2++;
            Debug.Log("Steel detected | count " + itemCount2);
        }
    }
}
