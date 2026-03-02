using UnityEngine;

public class PipeScript : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float deathZone;
    BirdScript birdScript;

    void Start()
    {
        birdScript = FindAnyObjectByType<BirdScript>();
    }

    void Update()
    {
        if (birdScript.isAlive)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            // or
            // transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            BoxCollider2D[] colliders = GetComponentsInChildren<BoxCollider2D>();
            foreach ( BoxCollider2D col in colliders)
            {
                col.enabled = false;
            }  
        }

        if (transform.position.x < deathZone)
        {
            Destroy(gameObject);
        }
    }
}
