using UnityEngine;

public class TrainController : MonoBehaviour 
{
    /* Location of where the train will stop */
    public Transform trainStop;
    private float speed = 3.0f;

    void Update () 
    {
		transform.position = Vector3.MoveTowards(transform.position, trainStop.position, speed * Time.deltaTime);
	}
}
