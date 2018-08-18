using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour 
{

    [SerializeField]
    public GameObject item; // The item to be spawned

    [SerializeField]
    public float sphereRadius = 0.1f;

    private float timer = 0f;
    private bool canPlace = true;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 3 && canPlace)
        {
            Instantiate(item, transform.position, transform.rotation);
            timer = 0f;
        }
	}

    public void OnTriggerEnter(Collider obj)
    {
        canPlace = false;
    }

    public void OnTriggerExit(Collider obj)
    {
        canPlace = true;
    }
}
