using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour 
{
    
    string[] inputItems; // The items that the train requires
    int   [] itemNeeded;  // The needed amount of each item

	void Start () 
    {
        int itemCount = Random.Range(0, 3); // Generate number of items
        inputItems = new string[itemCount];


        for (int i = 0; i < itemCount; i++)
        {
            string item = null;            // The required item
            int requiredAmount = 0;        // How much of the item is needed

            /* Generate the item */
            int randomItem = Random.Range(0, 5);
            if (randomItem == 0) item = "circuit";
            else if (randomItem == 1) item = "engine";
            else if (randomItem == 2) item = "glass";
            else if (randomItem == 3) item = "wheel";
            inputItems[i] = item;

            /* Generate the amount required */
            requiredAmount = Random.Range(0, 5);
            requiredAmount *= 50;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter(Collider obj)
    {
        Destroy(collider.gameObject);

    }
}
