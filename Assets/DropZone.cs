using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public void OnPointerEnter(PointerEventData eventData) {
		Debug.Log("OnPointerEnter");
	}

	public void OnDrop(PointerEventData eventData) {
		Debug.Log(eventData.pointerDrag.name + " was dropped onto " + gameObject.name);
		
		// Move the selected item card onto the board
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.returnParent = this.transform;
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		Debug.Log("OnPointerExit");
	}
}
