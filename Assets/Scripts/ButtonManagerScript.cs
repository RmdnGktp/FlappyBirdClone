using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject blackScreen;
    public static bool isPaused;

    public void Restart ()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame ()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        menuButton.SetActive(true);
        blackScreen.SetActive(true);
    }

    public void ResumeGame ()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        menuButton.SetActive(false);
        blackScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
