using UnityEngine;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int playerScore = 0;

    
    // [ContextMenu ("AddScore")]
    public void AddScore (int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
}
