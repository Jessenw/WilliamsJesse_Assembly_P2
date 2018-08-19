using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour 
{
    /* The different machines that the player can place, these should only be 
       templates */
    [SerializeField]
    private GameObject[] placeables;

    private int placeableItemIndex = 0;

    /* Same a placeables except these are the actual objects that will be 
       placed */
    [SerializeField]
    private GameObject[] finalPlaceables;

    /* The item that will be placed */
    private GameObject currentPlaceable;
    /* Remembers how many times the user has rotated the current item.
     * This is used to maintain rotation after an item has been placed
     */

    private int rotationCount = 0;
	
	void Update () 
    {
        if (currentPlaceable == null)
        {
            currentPlaceable = Instantiate(placeables[placeableItemIndex]);
            for (int i = 0; i < rotationCount; i++)
            {
                RotateObject();
            }

        }

        if (currentPlaceable != null)
        {
            ChangePlaceable();
            MoveToMouse();
            PlaceOnClick();
            RemoveMachine();
            RotateObjectOnPress();
        }
	}

    private void ChangePlaceable()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (placeableItemIndex < placeables.Length - 1)
            {
                placeableItemIndex++;
                Destroy(currentPlaceable);
                currentPlaceable = Instantiate(placeables[placeableItemIndex]);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (placeableItemIndex > 0)
            {
                placeableItemIndex--;
                Destroy(currentPlaceable);
                currentPlaceable = Instantiate(placeables[placeableItemIndex]);
            }
        }
    }

    private void MoveToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            currentPlaceable.transform.position = new Vector3(Mathf.Round(hit.point.x), 
                                                              Mathf.Round(hit.point.y), 
                                                              Mathf.Round(hit.point.z));
        }
    }

    public void PlaceOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Machine>() == null)
                {
                    Instantiate(finalPlaceables[placeableItemIndex], 
                                                    currentPlaceable.transform.position, 
                                                    currentPlaceable.transform.rotation);
                }
            }
        }
    }

    public void RemoveMachine()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Machine>() != null)
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    /* If the user presses "R" then the template should be rotated by 90 degrees */
    public void RotateObjectOnPress()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentPlaceable.transform.Rotate(transform.rotation.x, 
                                              transform.rotation.y + 90, 
                                              transform.rotation.z);

            rotationCount++;
            if (rotationCount > 3)
            {
                rotationCount = 0;
            }
        }
    }

    /* When a new template item is generated it should have the same orientation
     * as the previously placed object */
    public void RotateObject()
    {
        currentPlaceable.transform.Rotate(transform.rotation.x, 
                                          transform.rotation.y + 90, 
                                          transform.rotation.z);
    }
}
