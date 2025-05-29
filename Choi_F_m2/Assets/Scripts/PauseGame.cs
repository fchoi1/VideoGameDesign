using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = true;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Time.timeScale = isPaused ? 0f : 1f;
            isPaused = !isPaused;
        }
    }
}
