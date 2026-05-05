using UnityEngine;
using UnityEngine.InputSystem;
public class Restart : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = new Vector3(0, 5, 0);
        transform.rotation = Quaternion.identity;
    }
}
