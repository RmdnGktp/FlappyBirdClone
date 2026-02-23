using UnityEngine;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int playerScore = 0;
    
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
}
