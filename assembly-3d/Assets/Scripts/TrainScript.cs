using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainScript : MonoBehaviour 
{
    [SerializeField]
    public Text uiText;

    [SerializeField]
    public Transform offScreenTrainStop;

    public float offScreenTimer = 10.0f;

    [SerializeField]
    public float speed = 2.0f;
    
    string[] requiredItems; // The items that the train requires
    int[] itemNeeded;  // The needed amount of each item

	void Start () 
    {
        NewTrain();
	}
	
	// Update is called once per frame
	void Update () 
    {
        int itemCount = itemNeeded[0];
        string item = requiredItems[0];
        uiText.text = item + " [" + itemCount + "]";

        if (itemCount <= 0)
        {
            
            NextTrain();
        }
	}

    void NewTrain()
    {
        int itemCount = Random.Range(1, 2); // Generate number of items
        requiredItems = new string[itemCount];
        itemNeeded = new int[itemCount];

        for (int i = 0; i < itemCount; i++)
        {
            string item = null;            // The required item
            int requiredAmount = 0;        // How much of the item is needed

            /* Generate the item */
            int randomItem = Random.Range(0, 4);
            /* Debug */
            randomItem = 1;
            if (randomItem == 0) item = "circuit";
            else if (randomItem == 1) item = "engine";
            else if (randomItem == 2) item = "glass";
            else if (randomItem == 3) item = "wheel";
            requiredItems[i] = item;

            /* Generate the amount required */
            requiredAmount = Random.Range(1, 5);
            requiredAmount *= 10;
            /* Debug */
            requiredAmount = 3;
            itemNeeded[0] = requiredAmount;
        }
    }

    void NextTrain()
    {
        //Debug.Log("monkey");
        TrainController component = transform.GetComponent<TrainController>();
        component.enabled = false;
        transform.position = Vector3.MoveTowards(transform.position, offScreenTrainStop.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject gameObj = col.gameObject;
        if ((gameObj.GetComponent<Engine>() != null) && (requiredItems[0] == "engine"))
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
