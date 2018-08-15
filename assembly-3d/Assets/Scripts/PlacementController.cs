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
	
	// Update is called once per frame
	void Update () 
    {
        HandleInput();

        if (currentPlaceable != null)
        {
            MoveToMouse();
        }
	}

    private void HandleInput()
    {
        if (Input.GetKeyDown(hotkey))
        {
            if (currentPlaceable == null)
            {
                currentPlaceable = Instantiate(placeable);
            }
            else
            {
                Destroy(currentPlaceable);
            }
        }
    }

    private void MoveToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // currentPlaceable.transform.position = hit.point;
            currentPlaceable.transform.position = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
        }
    }
}
