using UnityEngine;

public class PipeScript : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float deathZone;
    
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        // or
        // transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < deathZone)
        {
            Destroy(gameObject);
        }
    }
}
