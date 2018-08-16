using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour 
{

    [SerializeField]
    public GameObject item; // The item to be spawn

    private float timer = 0f;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Vector3 checkBoxCenter = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
            Vector3 checkBox = new Vector3(0.2f, 0.2f, 0.2f);
            if (Physics.CheckBox(checkBoxCenter, checkBox))
            {
                Debug.Log("Contains");
            }
            else
            {
                Instantiate(item, transform.position, transform.rotation);
            }
            timer = 0f;
        }
	}
}
