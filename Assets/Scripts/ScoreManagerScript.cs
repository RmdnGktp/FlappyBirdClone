using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    int playerScore = 0;
    [SerializeField] TextMeshProUGUI EndGameScoreText;
    int endgameScore;
    [SerializeField] TextMeshProUGUI BestScoreText;
    int bestScore = 0;
    [SerializeField] Sprite[] numberSprites; 
    [SerializeField] GameObject digitPrefab;
    [SerializeField] Transform scoreContainer;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer ("Pipe");

        if (collision.gameObject.layer == layerIndex)
        {
            AddScore(1);
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
        endgameScore = playerScore;
        EndGameScoreText.text = endgameScore.ToString();

        bestScore = PlayerPrefs.GetInt("bestScore",0);
        if (endgameScore > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", playerScore);
            PlayerPrefs.Save();
            BestScoreText.text = playerScore.ToString();
        }
        else
        {
            BestScoreText.text = bestScore.ToString();
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
}
