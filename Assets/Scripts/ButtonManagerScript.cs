using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
    public void Restart ()
    {
        SceneManager.LoadScene(0);
    }
}
