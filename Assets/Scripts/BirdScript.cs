using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Collections;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float flapStrength;
    public bool isAlive = true;
    [SerializeField] PipeSpawnerScript spawnPipe;
    public bool gameStarted = false;
    [SerializeField] GameObject startSprites;
    [SerializeField] float gravityStrength;
    [SerializeField] ScoreManagerScript scoreManager;
    [SerializeField] GameObject scoreContainer;
    SoundManagerScript soundManagerScript;
    [SerializeField] GameOverBoardScript gameOverBoardScript;
    [SerializeField] float rotationSpeed;
    [SerializeField] Image flashImage;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] FloorScrollScript floorScrollScript;
    float deadZoneY = 5.0f;

    void Start()
    {
        soundManagerScript = FindFirstObjectByType<SoundManagerScript>();
    }

    void Update()
    {
        if (ButtonManagerScript.isPaused) return;
        
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

        if (transform.position.y > deadZoneY && isAlive)
        {
            GameOver();
        }
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
        pauseMenu.SetActive(true);
        soundManagerScript.isAlive = true;
        
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

     void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer ("Pipe");

        if (collision.gameObject.layer == layerIndex)
        {
            scoreManager.AddScore(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
           GameOver(); 
        }
        
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
        StartCoroutine(FlashCoroutine());
        isAlive = false;
        soundManagerScript.isAlive = false;
        spawnPipe.cancelSpawn();
        gameObject.GetComponent<Animator>().enabled = false;
        gameOverBoardScript.isGameOver();
        scoreManager.GameOverScore();
        scoreContainer.SetActive(false);
        pauseMenu.SetActive(false);
        floorScrollScript.speed = 0f;
    }

    void playFallingSound ()
    {
        soundManagerScript.playFalling();
    }

    IEnumerator FlashCoroutine ()
    {   
        flashImage.color = new Color(1, 1, 1, 1);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 5f;

            float alpha = Mathf.Lerp(1f, 0f, t);
            flashImage.color = new Color(1, 1, 1, alpha);

            yield return null;
        }
    }

    
}
