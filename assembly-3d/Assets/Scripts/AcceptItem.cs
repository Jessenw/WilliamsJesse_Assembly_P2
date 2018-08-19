using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles the accepting and processing of items for machines
 */
public class AcceptItem : MonoBehaviour {

    [SerializeField]
    private GameObject output; // The item that will be created

    /* Counts for how many of each item there are */
    private int itemCount1 = 0;
    private int itemCount2 = 0;

    /* How long it takes for the output to be created */
    private float timer = 2.0f;

    private string currentRecipe = "";

    void Update()
    {
    }

    void buildEngine()
    {
        /* If the recipe is satisfied */
        if ((itemCount2 >= 2) && (itemCount1 >= 1))
        {
            if (timer < 0)
            {
                Vector3 outputPos = new Vector3(transform.position.x + 1.5f,
                                               transform.position.y + 1.0f,
                                               transform.position.z);
                Instantiate(output, outputPos, transform.rotation);

                /* Remove items from count and reset timer */
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
        if (currentRecipe.Equals("engine"))
        {
            /* Check if the item is required by the recipe. If it is, increment
            * the appriopriate item count and destroy the item
            */

            Copper copper = item.gameObject.GetComponent<Copper>();
            if (copper != null)
            {
                Destroy(item.gameObject);
                itemCount1++;
            }

            Steel steel = item.gameObject.GetComponent<Steel>();
            if (steel != null)
            {
                Destroy(item.gameObject);
                itemCount2++;
            }
        }
        else if (currentRecipe.Equals("circuit"))
        {
            Plastic plastic = item.gameObject.GetComponent<Plastic>();
            if ()
        }
    }

    public void UpdateRecipe(string recipe)
    {
        Debug.Log("New recipe is: " + recipe);
        currentRecipe = recipe;
    }
}
