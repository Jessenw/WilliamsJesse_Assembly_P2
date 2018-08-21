using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Ends the current game if the level timer expires */
public class GameOver : MonoBehaviour 
{
	void Update () 
    {


        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
