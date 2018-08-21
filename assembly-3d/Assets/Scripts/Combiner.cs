using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles the accepting and processing of items for machines
 */
public class Combiner : MonoBehaviour {

    [SerializeField]
    private GameObject engine;
    [SerializeField]
    private GameObject wheel;
    [SerializeField]
    private GameObject gear;
    [SerializeField]
    private GameObject glass;
    [SerializeField]
    private GameObject circuit;

    /* Counts for how many of each item there are */
    private int itemCount1 = 0;
    private int itemCount2 = 0;

    private int item1Cost = 100;
    private int item2Cost = 100;

    /* How long it takes for the output to be created */
    private float timer = 0.0f;
    private float recipeTimer = 0.0f;

    private string currentRecipe = "";

    void Update() { if (!currentRecipe.Equals("")) buildOutput(); }

    void buildOutput()
    {
        /* If the recipe is satisfied */
        if ((itemCount1 >= item1Cost) && (itemCount2 >= item2Cost))
        {
            if (timer < 0)
            {
                Vector3 outputPos = new Vector3(transform.position.x + 1.0f,
                                               transform.position.y + 1.0f,
                                               transform.position.z);
                
                if (currentRecipe.Equals("engine")) Instantiate(engine, outputPos, transform.rotation);
                else if (currentRecipe.Equals("wheel")) Instantiate(wheel, outputPos, transform.rotation);
                else if (currentRecipe.Equals("gear")) Instantiate(gear, outputPos, transform.rotation);
                else if (currentRecipe.Equals("glass")) Instantiate(glass, outputPos, transform.rotation);
                else if (currentRecipe.Equals("circuit")) Instantiate(circuit, outputPos, transform.rotation);


                /* Remove items from count and reset timer */
                itemCount2 -= item1Cost;
                itemCount1 -= item2Cost;
                timer = recipeTimer;
            }
            else timer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider item)
    {
        if (currentRecipe == "engine")
        {
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
        else if (currentRecipe.Equals("wheel"))
        {
            Steel steel = item.gameObject.GetComponent<Steel>();
            if (steel != null)
            {
                Destroy(item.gameObject);
                itemCount1++;
                itemCount2++;
            }
        }
        else if (currentRecipe.Equals("gear"))
        {
            Steel steel = item.gameObject.GetComponent<Steel>();
            if (steel != null)
            {
                Destroy(item.gameObject);
                itemCount1++;
            }

            Rubber rubber = item.gameObject.GetComponent<Rubber>();
            if (rubber != null)
            {
                Destroy(item.gameObject);
                itemCount2++;
            }
        }
        else if (currentRecipe.Equals("glass"))
        {
            Sand sand = item.gameObject.GetComponent<Sand>();
            if (sand != null)
            {
                Destroy(item.gameObject);
                itemCount1++;
                itemCount2++;
            }
        }
        else if (currentRecipe.Equals("circuit"))
        {
            Copper copper = item.gameObject.GetComponent<Copper>();
            if (copper != null)
            {
                Destroy(item.gameObject);
                itemCount1++;
            }

            Plastic plastic = item.gameObject.GetComponent<Plastic>();
            if (plastic != null)
            {
                Destroy(item.gameObject);
                itemCount2++;
            }
        }
    }

    /*
     * This function is called by the combiner's modal dialog buttons
     */
    public void UpdateRecipe(string recipe)
    {
        Debug.Log("New recipe is: " + recipe);
        currentRecipe = recipe;

        /* Set the parameters of the recipe 
         * 
         * itemCost = the number of associated materials required to build
         * timer = how long it will take to build
         */
        if (recipe.Equals("engine"))
        {
            item1Cost = 2; // Copper
            item2Cost = 2; // Steel
            recipeTimer = 2.0f;
        }
        else if (recipe.Equals("wheel"))
        {
            item1Cost = 3; // Steel
            item2Cost = 0; // Null
            recipeTimer = 2.0f;
        }
        else if (recipe.Equals("gear"))
        {
            item1Cost = 2; // Steel
            item2Cost = 1; // Rubber
            recipeTimer = 1.0f;
        }
        else if (recipe.Equals("glass"))
        {
            item1Cost = 3; // Sand
            item2Cost = 0; // Null
            recipeTimer = 3.0f;
        }
        else if (recipe.Equals("circuit"))
        {
            item1Cost = 3; // Copper
            item2Cost = 1; // Plastic
            recipeTimer = 3.0f;
        }

        /* Reset the count when changing the recipe */
        itemCount1 = 0;
        itemCount2 = 0;
    }
}
