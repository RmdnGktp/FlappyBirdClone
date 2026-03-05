// using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManagerScript : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject blackScreen;
    public static bool isPaused;
    float fadeSpeed = 3f;
    SoundManagerScript soundManagerScript;

    void Start()
    {
        soundManagerScript = FindFirstObjectByType<SoundManagerScript>();
        StartCoroutine(FadeIn());
    } 

    public void Restart ()
    {     
        StartCoroutine(FadeOut(1));
    }

    public void PauseGame ()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        menuButton.SetActive(true);
        blackScreen.GetComponent<Image>().color = new Color (0f, 0f, 0f, 0.6f);
    }

    public void ResumeGame ()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        menuButton.SetActive(false);
        blackScreen.GetComponent<Image>().color = new Color (0f, 0f, 0f, 0f);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu ()
    {
        StartCoroutine(FadeOut(0));
        Time.timeScale = 1f;
        isPaused = false;
    }

    public IEnumerator FadeIn()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            blackScreen.GetComponent<Image>().color = new Color (0f, 0f, 0f, alpha);
            yield return null;
        }
    }
    
    public IEnumerator FadeOut( int sceneNumber)
    {   
        soundManagerScript.playSwoosh();
        
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            blackScreen.GetComponent<Image>().color = new Color (0f, 0f, 0f, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneNumber);
    }
}