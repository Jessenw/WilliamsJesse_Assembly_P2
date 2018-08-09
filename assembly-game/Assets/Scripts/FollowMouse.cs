using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;

    void update()
    {
        if (Input.GetMouseButton(1))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
}