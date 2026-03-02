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
    [SerializeField] float rotationSpeed;


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

        RotateBird(rotationSpeed);
    }

    void Jump ()
    {
       myRigidbody.linearVelocity = Vector2.up * flapStrength;
       myRigidbody.rotation = 30f;
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

    void RotateBird(float speed)
    {
        if (gameStarted)
        {
            float angle = myRigidbody.linearVelocity.y * speed;
            angle = Mathf.Clamp(angle, -90f, 30f);
            myRigidbody.rotation = angle;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();

        int layerIndex = LayerMask.NameToLayer ("Pipe");
        if (collision.gameObject.layer == layerIndex)
        {
            Invoke("playFallingSound", 0.3f);
        }

        int layerIndexFloor = LayerMask.NameToLayer ("Floor");
        if (collision.gameObject.layer == layerIndexFloor)
        {
            myRigidbody.simulated = false;
        }
    }

    void GameOver ()
    {
        soundManagerScript.playCollision();
        isAlive = false;
        gameOverScene.SetActive(true);
        spawnPipe.cancelSpawn();
        gameObject.GetComponent<Animator>().enabled = false;
        scoreManager.GameOverScore();
        scoreContainer.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer ("Pipe");

        if (collision.gameObject.layer == layerIndex)
        {
            scoreManager.AddScore(1);
        }
    }

    void playFallingSound ()
    {
        soundManagerScript.playFalling();
    }
}
