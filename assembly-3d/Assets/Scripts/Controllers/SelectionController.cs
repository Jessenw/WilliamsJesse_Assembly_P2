using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour 
{
    private bool isShowing = true;

	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameObject dialog = hit.collider.gameObject.transform.Find("CombinerDialog").gameObject;
                isShowing = !isShowing;
                dialog.SetActive(isShowing);
            }
        }
	}
}
