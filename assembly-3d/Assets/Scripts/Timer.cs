using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour 
{
    public Text timerText;

    public float timer;
    private bool setGameOverCanvas = true;

    private void Start() { timer = 35.0f; }

    void Update () 
    {
        /* Update and display timer */
        int roundedTimer = Mathf.RoundToInt(timer);
        timerText.text = "Time left: " + roundedTimer.ToString() + " seconds";
        timer -= Time.deltaTime;

        GameObject timerCanvas = transform.Find("TimerCanvas").gameObject;
        GameObject uiTimer = timerCanvas.transform.Find("Timer").gameObject;

        /* When game timer expires, end the game */
        if (timer <= 0 && setGameOverCanvas)
        {
            timer = 0; // Stop timer from going below 0

            /* Show game over canvas */
            GameObject gameOverCanvas = transform.Find("GameOverCanvas").gameObject;
            gameOverCanvas.SetActive(true);

            /* Reset game on key press */
            if (Input.GetKeyDown(KeyCode.P)) 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
