using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= 0.25)
        {
            Destroy(this.gameObject);
        }
	}
}
