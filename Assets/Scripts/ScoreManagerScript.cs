using UnityEngine;
using TMPro;
using System.Data.SqlTypes;

public class ScoreManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int playerScore = 0;
    [SerializeField] TextMeshProUGUI EndGameScoreText;
    int endgameScore;
    [SerializeField] TextMeshProUGUI BestScoreText;
    int bestScore = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer ("Pipe");

        if (collision.gameObject.layer == layerIndex)
        {
            AddScore(1);
        }
    }

    // [ContextMenu ("AddScore")]
    public void AddScore (int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
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
}
