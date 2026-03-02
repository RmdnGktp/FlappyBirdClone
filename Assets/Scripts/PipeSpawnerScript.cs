using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float spawnRate;
    [SerializeField] float heightOffset;

    public void startSpawn()
    {
        InvokeRepeating ("spawnPipe", 0f, spawnRate);
    }

    [ContextMenu ("cancelSpawn")]
    public void cancelSpawn()
    {
        CancelInvoke();
    }

    void spawnPipe ()
    {
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;

        Instantiate (pipe, new Vector3 (transform.position.x, Random.Range(maxHeight,minHeight), transform.position.z), transform.rotation, gameObject.transform);
    }
}
