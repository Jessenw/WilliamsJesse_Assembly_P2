using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour 
{

    [SerializeField]
    private GameObject placeable;

    [SerializeField]
    private KeyCode hotkey = KeyCode.A;

    private GameObject currentPlaceable;

    private int rotationCount = 0;
	
	// Update is called once per frame
	void Update () 
    {
        if (currentPlaceable == null)
        {
            currentPlaceable = Instantiate(placeable);
            for (int i = 0; i < rotationCount; i++)
            {
                RotateObject();
            }

        }

        if (currentPlaceable != null)
        {
            MoveToMouse();
            PlaceOnClick();
            RotateObjectOnPress();
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
            currentPlaceable = null;
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
