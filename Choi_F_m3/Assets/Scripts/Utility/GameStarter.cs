using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame() called!");
        SceneManager.LoadScene("demo");
        Time.timeScale = 1f;
    }
}