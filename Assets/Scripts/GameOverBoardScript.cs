using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverBoardScript: MonoBehaviour
{
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameOverBoard;
    Image textImage;
    [SerializeField] GameObject gameOverScore;
    [SerializeField] GameObject gameOverButtons;
    SoundManagerScript soundManagerScript;
    [SerializeField] float speed = 5f;
    float textCurrentPosition;
    float boardCurrentPosition;
    float textStartPosition = 600f; 
    float boardStartPosition = -1250f;

    
    void Start()
    {
        textCurrentPosition = gameOverText.GetComponent<RectTransform>().anchoredPosition.y;
        textImage = gameOverText.GetComponent<Image>();
        boardCurrentPosition = gameOverBoard.GetComponent<RectTransform>().anchoredPosition.y;
        soundManagerScript = FindFirstObjectByType<SoundManagerScript>();
        gameOverText.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0, textStartPosition);
        gameOverBoard.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0, boardStartPosition);
    }

    
    public void isGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {   
        yield return new WaitForSeconds(0.5f);
        textImage.enabled = true;
        textImage.color = new Color(1f, 1f, 1f, 0);
        soundManagerScript.playSwoosh();
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;

            float alpha = Mathf.Lerp (0, 1f, t);
            textImage.color = new Color(1f, 1f, 1f, alpha);
            float newPositionY = Mathf.SmoothStep (textStartPosition, textCurrentPosition, t);
            gameOverText.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0, newPositionY);
            
            yield return null;
        }

        Debug.Log ("Text Animation");
        yield return new WaitForSeconds(0.5f);

        soundManagerScript.playSwoosh();
        gameOverBoard.SetActive(true);
        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            float newPositionY = Mathf.Lerp (boardStartPosition, boardCurrentPosition, t);
            gameOverBoard.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0, newPositionY);
            
            yield return null;
        }
        
        Debug.Log ("Board Animation");
        yield return new WaitForSeconds(0.5f);

        gameOverButtons.SetActive(true);
        Debug.Log ("Show Buttons");
        yield return null;

    }
}
