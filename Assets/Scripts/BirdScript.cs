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
    [SerializeField] GameObject startScene;
    [SerializeField] float gravityStrength;


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
    }

    void StartGame ()
    {
        gameStarted = true;
        startScene.SetActive(false);
        myRigidbody.gravityScale = gravityStrength;
        spawnPipe.startSpawn();
        
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

    }
}
