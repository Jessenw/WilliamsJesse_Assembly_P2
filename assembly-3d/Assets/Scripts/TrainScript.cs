using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour 
{
    
    string[] requiredItems; // The items that the train requires
    int   [] itemNeeded;  // The needed amount of each item

	void Start () 
    {
        int itemCount = Random.Range(1, 2); // Generate number of items
        requiredItems = new string[itemCount];

        for (int i = 0; i < itemCount; i++)
        {
            string item = null;            // The required item
            int requiredAmount = 0;        // How much of the item is needed

            /* Generate the item */
            int randomItem = Random.Range(0, 4);
            if (randomItem == 0) item = "circuit";
            else if (randomItem == 1) item = "engine";
            else if (randomItem == 2) item = "glass";
            else if (randomItem == 3) item = "wheel";
            requiredItems[i] = item;
            Debug.Log("Item: " + item);

            /* Generate the amount required */
            requiredAmount = Random.Range(1, 5);
            requiredAmount *= 10;
            Debug.Log("Item amount: " + requiredAmount);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        GameObject gameObj = col.gameObject;
        if (gameObj.GetComponent<Engine>() != null && requiredItems[0] == "engine")
        {
            Destroy(gameObj);
            itemNeeded[0]--;
        }
        else if (gameObj.GetComponent<Circuit>() != null && requiredItems[0] == "circuit")
        {
            Destroy(gameObj);
            itemNeeded[0]--;
        }
    }
}
