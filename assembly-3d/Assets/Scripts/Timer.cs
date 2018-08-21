using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour 
{
    [SerializeField]
    public Text uiText;

    public float timer = 0.0f;
    private bool setGameOverCanvas = true;

    private void Start()
    {
        timer = 120.0f;
    }

    void Update () 
    {
        int roundedTimer = Mathf.RoundToInt(timer);
        uiText.text = "Time left: " + roundedTimer.ToString() + " seconds";
        timer -= Time.deltaTime;

        GameObject timerCanvas = transform.Find("TimerCanvas").gameObject;
        GameObject uiTimer = timerCanvas.transform.Find("Timer").gameObject;

        if (timer <= 0 && setGameOverCanvas)
        {
            timer = 0;
            GameObject gameOverCanvas = transform.Find("GameOverCanvas").gameObject;
            gameOverCanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
}
