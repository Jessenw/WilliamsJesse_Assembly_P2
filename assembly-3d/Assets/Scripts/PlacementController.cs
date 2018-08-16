using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] placeables;

    [SerializeField]
    private GameObject[] finalPlaceables;

    private GameObject currentPlaceable;
    private int rotationCount = 0;
    private int placeableItemIndex = 0;
	
	// Update is called once per frame
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
            currentPlaceable.transform.position = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
        }
    }

    public void PlaceOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(finalPlaceables[placeableItemIndex], currentPlaceable.transform.position, currentPlaceable.transform.rotation);
        }
    }

    public void RotateObjectOnPress()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentPlaceable.transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);

            rotationCount++;
            if (rotationCount > 3)
            {
                rotationCount = 0;
            }
        }
    }

    public void RotateObject()
    {
        currentPlaceable.transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
    }
}
