using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script allows an item to follow the mouse with grid snapping. If the player clicks
 * the left mouse button, a new item finalObject is created at the grid position.
 * This implementation is sourced from: https://www.youtube.com/watch?v=D9ZU0mfukQE
 */
public class PlaceScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject; // The object that will be placed

    private Vector2 mousePos;
	
	// Update is called once per frame
	void Update ()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*  Round the position so that is snaps to the grid and assign to position */
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        /* If the left mouse button is pressed, instantiate the finalObject */
        if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
        {
            /* Object to instantiate, position of finalObject, rotation of finalObject */
            Instantiate(finalObject, transform.position, Quaternion.identity);
        }
	}
}
