using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script automatically spawns new GameObject's after a specified time */
public class SpawnItem : MonoBehaviour 
{
    [SerializeField]
    private GameObject item; // The item to be spawned

    [SerializeField]
    private float spawnRate = 1.0f; // How many seconds until the item spawns again

    private float timer = 0f;
    private bool canSpawn = true; // True = new item can be spawned
	
	void Update () 
    {
        timer += Time.deltaTime;
        if (timer > spawnRate && canSpawn)
        {
            Instantiate(item, transform.position, transform.rotation);
            timer = 0f;
        }
	}

    /* Trigger functions which determine whether there is free space to
     * spawn an item */
    public void OnTriggerEnter(Collider obj) { canSpawn = false; }
    public void OnTriggerExit(Collider obj) { canSpawn = true; }
}
