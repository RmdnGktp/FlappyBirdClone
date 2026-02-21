using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{
    ScoreManagerScript myScoreManager;

    void Start()
    {
        myScoreManager = FindFirstObjectByType<ScoreManagerScript>();
        //myScoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer ("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            myScoreManager.AddScore(1);
        }
    }
}
