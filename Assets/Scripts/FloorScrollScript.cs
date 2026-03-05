using UnityEngine;

public class FloorScrollScript : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] float width;
   
    void Update()
    {
        if (ButtonManagerScript.isPaused) return;

        transform.Translate (Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -width)
        {
            transform.position += new Vector3(width, 0f, 0f);
        }
    }
}
