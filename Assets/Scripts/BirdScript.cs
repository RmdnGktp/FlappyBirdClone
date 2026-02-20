using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BirdScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float flapStrength;
    
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Jump ();
        }
    }

    void Jump ()
    {
       myRigidbody.linearVelocity = Vector2.up * flapStrength;
    }
}
