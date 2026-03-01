using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BirdScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float flapStrength;
    public bool isAlive = true;
    [SerializeField] GameObject gameOverScene;
    [SerializeField] PipeSpawnerScript spawnPipe;
    public bool gameStarted = false;
    [SerializeField] GameObject startSprites;
    [SerializeField] float gravityStrength;
    [SerializeField] ScoreManagerScript scoreManager;
    [SerializeField] GameObject scoreContainer;
    [SerializeField] SoundManagerScript soundManagerScript;


    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && isAlive && gameStarted)
        {
            Jump ();
        }
        else if (Mouse.current.leftButton.wasPressedThisFrame && !gameStarted)
        {
            StartGame();
            Jump();
        }
    }

    void Jump ()
    {
       myRigidbody.linearVelocity = Vector2.up * flapStrength;
       soundManagerScript.playFlap();
    }

    void StartGame ()
    {
        gameStarted = true;
        startSprites.SetActive(false);
        myRigidbody.gravityScale = gravityStrength;
        spawnPipe.startSpawn();
        scoreContainer.SetActive(true);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver ()
    {
        isAlive = false;
        gameOverScene.SetActive(true);
        spawnPipe.cancelSpawn();
        gameObject.GetComponent<Animator>().enabled = false;
        scoreManager.GameOverScore();
        scoreContainer.SetActive(false);
        soundManagerScript.playCollision();
    }
}
