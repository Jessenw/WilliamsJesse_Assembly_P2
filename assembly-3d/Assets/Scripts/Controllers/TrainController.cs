using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour 
{
    /* Location of where the train will stop */
    [SerializeField]
    public Transform trainStop;

    /* How long until the train enters the scene */
    private float entryTimer = 2.0f;

    /* How long until the train leaves */
    private float waitTimer = 15.0f;

    private float timer = 2.0f;
    private float speed = 2.0f;

    // Update is called once per frame
    void Update () 
    {
		if (timer < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, trainStop.position, speed * Time.deltaTime);
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
}
