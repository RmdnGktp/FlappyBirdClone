using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    int playerScore = 0;
    int bestScore = 0;
    [SerializeField] Sprite[] numberSprites; 
    [SerializeField] Sprite[] awardsSprites;
    [SerializeField] GameObject digitPrefab;
    [SerializeField] Transform scoreContainer;
    [SerializeField] Transform endGameScoreContainer;
    [SerializeField] Transform bestScoreContainer;
    [SerializeField] Transform AwardsContainer;
    [SerializeField] GameObject awardPrefab;
    [SerializeField] SoundManagerScript soundManagerScript;

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer ("Pipe");

        if (collision.gameObject.layer == layerIndex)
        {
            AddScore(1);
            soundManagerScript.playCoin();
        }
    }

    [ContextMenu ("AddScore")]
    public void AddScore (int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UpdateScoreVisual(playerScore);
    }

    public void GameOverScore ()
    {
        UpdateEndGameScoreVisual (playerScore);
        AwardsManager (playerScore);
        bestScore = PlayerPrefs.GetInt("bestScore",0);

        if (playerScore > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", playerScore);
            PlayerPrefs.Save();
            UpdateBestScoreVisual(playerScore);
        }
        else
        {
            UpdateBestScoreVisual(bestScore);
        }
        
    }

    void UpdateScoreVisual(int score)
    {
        foreach (Transform child in scoreContainer)
        {
           Destroy(child.gameObject);
        }

        string scoreString = score.ToString();

        foreach (char digit in scoreString)
        {
           GameObject newDigit = Instantiate(digitPrefab, scoreContainer);
           int index = digit - '0';
           newDigit.GetComponent<Image>().sprite = numberSprites[index];
        }
    }

    void UpdateEndGameScoreVisual (int score)
    {
        foreach (Transform child in endGameScoreContainer)
        {
            Destroy(child.gameObject);
        }

        string scoreString = score.ToString();

        foreach (char digit in scoreString)
        {
            GameObject newDigit = Instantiate (digitPrefab, endGameScoreContainer);
            int index = digit - '0';
            newDigit.GetComponent<Image>().sprite = numberSprites[index];
        }
    }

    void UpdateBestScoreVisual (int score)
    {
        foreach (Transform child in bestScoreContainer)
        {
            Destroy(child.gameObject);
        }

        string scoreString = score.ToString();

        foreach(char digit in scoreString)
        {
            GameObject newDigit = Instantiate (digitPrefab, bestScoreContainer);
            int index = digit -'0';
            newDigit.GetComponent<Image>().sprite = numberSprites[index];
        }
    }

    void AwardsManager (int score)
    {
        if (score >= 10 && score < 20)
        {
            GameObject newAward = Instantiate (awardPrefab, AwardsContainer);
            newAward.GetComponent<Image>().sprite = awardsSprites [0]; 
        }
        else if (score >= 20)
        {
            GameObject newAward = Instantiate (awardPrefab, AwardsContainer);
            newAward.GetComponent<Image>().sprite = awardsSprites [1]; 
        }
        
    }
}
